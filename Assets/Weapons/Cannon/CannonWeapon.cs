using System.Collections;
using UnityEngine;

public class CannonWeapon : Weapon 
{
    [SerializeField] int damage;
    [SerializeField] Projectile projectile;
    [SerializeField] float throwForce;

    public override WeaponID ID => WeaponID.Cannon;
    protected override WeaponLevelData[] levelsData => new WeaponLevelData[]
    {
        new WeaponLevelData("New Weapon: <color=orange>Cannon","Shoots huge projectiles"),
        new WeaponLevelData("Cannon II","TODO"),
        new WeaponLevelData("Cannon III","TODO"),
        new WeaponLevelData("Cannon IV","TODO"),
        new WeaponLevelData("Cannon V","TODO"),
    };

    public override IEnumerator OnCooldownFinish()
    {
        var target = Provider.Spaceship.GetComponent<Targeting>().Target;
        if (target == null) 
            yield return null;

        Projectile projectileInstance = projectile.BuildNew(owner, owner.transform.position, Quaternion.identity);
        projectileInstance.Damage = damage;
        Vector2 direction = (target.transform.position - owner.transform.position).normalized;
        projectileInstance.Push(direction, throwForce);
    }
}
