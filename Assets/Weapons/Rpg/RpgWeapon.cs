using UnityEngine;

public class RpgWeapon : Weapon
{
    [SerializeField] Projectile projectile;
    [SerializeField] float throwForce;

    public override WeaponID ID => WeaponID.RPG;
    protected override WeaponLevelData[] levelsData => new WeaponLevelData[]
    {
        new WeaponLevelData("RPG I","Huge rocket launcher"),
        new WeaponLevelData("RPG II","TODO"),
        new WeaponLevelData("RPG III","TODO"),
        new WeaponLevelData("RPG IV","TODO"),
        new WeaponLevelData("RPG V","TODO"),
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
