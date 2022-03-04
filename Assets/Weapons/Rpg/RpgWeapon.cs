using UnityEngine;

public class RpgWeapon : Weapon
{
    [SerializeField] Projectile projectile;
    [SerializeField] float throwForce;

    public override WeaponID ID => WeaponID.RPG;
    protected override WeaponLevelData[] levelsData => new WeaponLevelData[]
    {
        new WeaponLevelData("T1","D1"),
        new WeaponLevelData("T2","D2"),
        new WeaponLevelData("T3","D3"),
        new WeaponLevelData("T4","D4"),
        new WeaponLevelData("T5","D5"),
    };

    public override void Trigger()
    {
        var target = Provider.Spaceship.GetComponent<Targeting>().Target;
        if (target == null)
            return;

        Projectile projectileInstance = projectile.BuildNew(owner, owner.transform.position, Quaternion.identity);
        projectileInstance.RotateTowards(target.transform);
        Vector2 direction = (target.transform.position - owner.transform.position).normalized;
        projectileInstance.Push(direction, throwForce);
    }
}
