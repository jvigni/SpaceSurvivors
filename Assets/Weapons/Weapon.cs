public abstract class Weapon
{
    public float CooldownSecs { get; }

    public Weapon(float cooldownSecs)
    {
        CooldownSecs = cooldownSecs;
    }

    public abstract void Trigger();
}
