using System.Collections.Generic;
using UnityEngine;

public enum WeaponUpgrade
{
    Cannon_pierce,
    Homming_DoubleShoot
}

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] float cooldownSecs;
    protected GameObject owner;
    bool autoShooting;
    protected GameObject NearestTarget => Provider.Spaceship.GetComponent<Targeting>().Target;
    protected bool HasUpgrade(WeaponUpgrade upgrade) => Provider.Spaceship.GetComponent<SpaceshipWeaponsManager>().HasUpgrade(upgrade);

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
