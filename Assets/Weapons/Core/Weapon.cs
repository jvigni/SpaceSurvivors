using System.Collections.Generic;
using UnityEngine;

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
    public Sprite Icon;
    [SerializeField] float cooldownSecs;

    protected GameObject owner;
    protected int level = 1;

    protected abstract WeaponLevelData[] levelsData { get; }

    public WeaponLevelData FirstLevelData => levelsData[0];
    public WeaponLevelData NextLevelData => levelsData[level]; //No hace falta un +1 ya que lvl arranca en 1 y el array en 0.
    public bool IsMaxLevel => level == MaxLevel;
    public int MaxLevel => 5;

    protected GameObject NearestTarget => Provider.Spaceship.GetComponent<Targeting>().Target;
    protected bool HasUpgrade(Upgrade upgrade) => Provider.Spaceship.GetComponent<SpaceshipUpgradesManager>().HasUpgrade(upgrade);

    bool autoShooting;

    public void Init(GameObject owner)
    {
        this.owner = owner;
    }

    public void LevelUp()
    {
        level++;
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
