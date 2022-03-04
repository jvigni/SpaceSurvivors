using UnityEngine;

public class CannonWeapon : Weapon 
{
    [SerializeField] Projectile projectile;
    [SerializeField] float throwForce;

    public override WeaponID ID => WeaponID.Cannon;
    protected override WeaponLevelData[] levelsData => new WeaponLevelData[]
    {
        new WeaponLevelData("Cannon I","Shoots huge projectiles"),
        new WeaponLevelData("Cannon II","TODO"),
        new WeaponLevelData("Cannon III","TODO"),
        new WeaponLevelData("Cannon IV","TODO"),
        new WeaponLevelData("Cannon V","TODO"),
    };

    public override void Trigger()
    {
        var target = Provider.Spaceship.GetComponent<Targeting>().Target;
        if (target == null) 
            return;

        Projectile projectileInstance = projectile.BuildNew(owner, owner.transform.position, Quaternion.identity);
        Vector2 direction = (target.transform.position - owner.transform.position).normalized;
        projectileInstance.Push(direction, throwForce);
    }
}
