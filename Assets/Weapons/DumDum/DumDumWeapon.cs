using UnityEngine;

public class DumDumWeapon : Weapon
{
    [SerializeField] float offset;
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] float throwForce;

    public override WeaponID ID => WeaponID.DumDum;
    protected override WeaponLevelData[] levelsData => new WeaponLevelData[]
    {
        new WeaponLevelData("New Weapon: <color=orange>DumDum","Fast shooting weapon"),
        new WeaponLevelData("DumDum II","TODO"),
        new WeaponLevelData("DumDum III","TODO"),
        new WeaponLevelData("DumDum IV","TODO"),
        new WeaponLevelData("DumDum V","TODO"),
    };

    public override void Trigger()
    {
        Projectile projectileInstance = projectilePrefab.BuildNew(owner, owner.transform.position, Quaternion.identity);
        BasicShooting(projectileInstance);
        //TargetedShooting(projectileInstance);
    }

    void BasicShooting(Projectile projectile)
    {
        projectile.transform.rotation = Provider.Spaceship.transform.rotation;

        offset *= -1;
        projectile.transform.Translate(Vector3.right * offset);

        Vector2 direction = transform.up;
        projectile.Push(direction, throwForce);
    }

    void TargetedShooting(Projectile projectile)
    {
        var target = Provider.Spaceship.GetComponent<Targeting>().Target;
        if (target == null)
            return;

        Vector2 direction = (target.transform.position - owner.transform.position).normalized;
        projectile.RotateTowards(target.transform);
        projectile.Push(direction, throwForce);
    }
}
