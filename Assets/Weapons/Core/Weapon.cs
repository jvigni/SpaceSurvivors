using System.Collections.Generic;
using UnityEngine;

public class WeaponLevelData
{
    public string title;
    public string desc;

    public WeaponLevelData(string title, string desc)
    {
        this.title = title;
        this.desc = desc;
    }
}

public abstract class Weapon : MonoBehaviour
{
    public string Title;
    public string Desc;
    public Sprite Icon;
    public Weapon nextUpgrade;
    [SerializeField] float cooldownSecs;

    protected GameObject owner;
    protected int level = 1;

    protected abstract WeaponLevelData[] levelsData { get; }
    public WeaponLevelData NextLevelData
    {
        get { return levelsData[level + 1]; }
    }

    protected GameObject NearestTarget => Provider.Spaceship.GetComponent<Targeting>().Target;
    protected bool HasUpgrade(Upgrade upgrade) => Provider.Spaceship.GetComponent<SpaceshipUpgradesManager>().HasUpgrade(upgrade);

    bool autoShooting;

    public void Init(GameObject owner)
    {
        this.owner = owner;
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
