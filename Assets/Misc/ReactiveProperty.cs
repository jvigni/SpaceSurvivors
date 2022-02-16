using System;
using System.Collections.Generic;

public class ReactiveProperty<T>
{
    List<Action<T>> callbacks = new List<Action<T>>();

    T _value;
    public T Value
    {
        get { return _value; }
        set
        {
            _value = value;
            ExecuteSubscriptions();
        }
    }

    public ReactiveProperty(T initialValue = default(T))
    {
        Value = initialValue;
    }

    public void Subscribe(Action<T> callback)
    {
        callback?.Invoke(_value);
        callbacks.Add(callback);
    }

    public void ClearAll()
    {
        callbacks.Clear();
    }

    void ExecuteSubscriptions()
    {
        callbacks.ForEach(subscription =>
        {
            subscription?.Invoke(_value);
        });
    }
}
