using UnityEngine;

public enum WeaponID
{
    Cannon,
    HommingMissile,
    DumDum,
    Flamethrower,
    RPG,
}

public class WeaponLevelData
{
    public string Title;
    public string Desc;

    public WeaponLevelData(string title, string desc)
    {
        Title = title;
        Desc = desc;
    }
}

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float cooldownSecs;
    public Sprite Icon;
    public WeaponLevelData FirstLevelData => levelsData[0];
    public WeaponLevelData NextLevelData => levelsData[level]; //No hace falta un +1 ya que lvl arranca en 1 y el array en 0.
    public bool IsMaxLevel => level == MaxLevel;
    public int MaxLevel => 5;

    protected GameObject owner;
    protected int level = 1;
    protected GameObject NearestTarget => Provider.Spaceship.GetComponent<Targeting>().Target;
    protected bool HasUpgrade(Upgrade upgrade) => Provider.Spaceship.GetComponent<SpaceshipUpgradesManager>().HasUpgrade(upgrade);

    public abstract WeaponID ID { get; }
    protected abstract WeaponLevelData[] levelsData { get; }
    protected virtual void DoOnLevelUp(int level) { }
    
    bool autoShooting;

    public void Init(GameObject owner)
    {
        this.owner = owner;
    }

    internal void OnUpgrade()
    {
        level++;
        DoOnLevelUp(level);
    }

    public void StartAutoshooting()
    {
        autoShooting = true;
        StartCooldown();
    }

    public void StopAutoshooting()
    {
        autoShooting = false;
    }

    void StartCooldown()
    {
        var cooldown = Provider.CooldownManager.Start(cooldownSecs);
        cooldown.OnFinish += _ => OnCooldownFinished();
    }

    void OnCooldownFinished()
    {
        if (!autoShooting)
            return;

        Trigger();
        StartCooldown();
    }

    public abstract void Trigger();
}
