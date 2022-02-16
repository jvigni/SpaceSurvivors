using System;

public enum EffectID
{
    Fireball, //EJ
}

public enum EffectAplicationBehaviour
{
    Unique, // If another one exists, the old gets eliminated
    Stackeable, // If another one exists, will merge
}

public abstract class Effect
{
    public event Action<Effect> OnExpire;
    public int Charges { get; protected set; }
    public EffectAplicationBehaviour AplicationBehaviour { get; protected set; }
    public EffectID ID;
    public Lifeform Owner;
    public Lifeform Caster;
    public string Description;

    public Effect(
        EffectID id,
        string desc,
        int charges,
        EffectAplicationBehaviour aplicationBehaviour)
    {
        ID = id;
        Description = desc;
        Charges = charges;
        AplicationBehaviour = aplicationBehaviour;
    }

    public void Expire()
    {
        DoOnExpire();
        OnExpire?.Invoke(this);
    }

    public void Stack(Effect anotherEffect)
    {
        Charges += anotherEffect.Charges;
        DoOnStack(anotherEffect);
    }

    protected void ReduceOneCharge()
    {
        Charges--;
        if (Charges == 0)
            Expire();
    }

    public virtual void DoOnExpire() { }
    public virtual void DoOnStack(Effect anotherEffect) { }
    public virtual void OnBeingAttacked(DmgInfo dmgInfo) { }
    public virtual void OnDamageReceibed(DmgInfo dmgInfo) { }
    public virtual void OnDamageDealt(int dmgAmount) { }
    public virtual DmgInfo ModifyOutgoingDamage(DmgInfo originalDmgInfo) { return originalDmgInfo; }
    public virtual DmgInfo ModifyIncomingDamage(DmgInfo originalDmgInfo) { return originalDmgInfo; }
}