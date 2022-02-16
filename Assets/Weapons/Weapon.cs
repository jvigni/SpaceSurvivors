public abstract class Weapon
{
    Cooldown cooldown;

    public Weapon(float cooldownSecs)
    {
        cooldown = new Cooldown(cooldownSecs);
        cooldown.OnFinish += Trigger;
    }

    public void TurnOn()
    {
        cooldown.Start(true);
    }

    public abstract void Trigger();
}
