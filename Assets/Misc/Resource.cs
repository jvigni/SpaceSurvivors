using System;

public class Resource
{
    private float amount;
    private float maxAmount;
    private Action<float> onAmountChanged;

    public Resource(float amount)
    {
        maxAmount = amount;
        this.amount = amount;
    }

    public Resource(float amount, Action<float> onAmountChanged)
    {
        maxAmount = amount;
        this.amount = amount;
        this.onAmountChanged = onAmountChanged;
    }

    public bool IsFull()
    {
        return amount >= maxAmount;
    }

    public bool Has(float amount)
    {
        return this.amount >= amount;
    }

    public void Decrease(float decrement)
    {
        amount -= decrement;
        if (amount < 0)
            amount = 0;

        onAmountChanged?.Invoke(amount);
    }

    public void Increase(float increment)
    {
        amount += increment;
        if (amount > maxAmount)
            amount = maxAmount;

        onAmountChanged?.Invoke(amount);
    }
}
