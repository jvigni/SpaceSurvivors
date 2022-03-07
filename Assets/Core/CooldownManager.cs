using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown
{
    public event Action OnFinish;
    public Func<IEnumerator> Action;
    public float Seconds;
    bool repeat;

    public Cooldown(float seconds, Func<IEnumerator> action, bool repeat = false)
    {
        Seconds = seconds;
        Action = action;
        this.repeat = repeat;
    }

    public void Start() => Provider.CooldownManager.StartCooldown(this);
    public void Stop() => Provider.CooldownManager.StopCooldown(this);

    public void Finish()
    {
        OnFinish?.Invoke();
        if (repeat) Start();
    }
}

public class CooldownManager : MonoBehaviour
{
    Dictionary<Cooldown, Coroutine> routines = new Dictionary<Cooldown, Coroutine>();

    private void Awake()
    {
        Provider.CooldownManager = this;
    }

    public void StartCooldown(Cooldown cooldown)
    {
        var routine = StartCoroutine(ManageCooldown(cooldown));
        routines.Add(cooldown, routine);
    }

    public void StopCooldown(Cooldown cooldown)
    {
        StopCoroutine(routines[cooldown]);
    }

    IEnumerator ManageCooldown(Cooldown cooldown)
    {
        yield return new WaitForSeconds(cooldown.Seconds);
        yield return StartCoroutine(cooldown.Action.Invoke());
        routines.Remove(cooldown);
        cooldown.Finish();
    }
}
