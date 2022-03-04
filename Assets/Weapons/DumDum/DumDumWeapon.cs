using UnityEngine;

public class DumDumWeapon : Weapon
{
    [SerializeField] int damage;
    [SerializeField] float offset;
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] float throwForce;
    [SerializeField] float lv2CooldownReduction;
    [SerializeField] float lv5CooldownReduction;

    public override WeaponID ID => WeaponID.DumDum;
    protected override WeaponLevelData[] levelsData => new WeaponLevelData[]
    {
        new WeaponLevelData("New Weapon: <color=orange>DumDum","Fast shooting weapon"),
        new WeaponLevelData("DumDum II","Rate of fire Increased"),
        new WeaponLevelData("DumDum III","Double Barrel"),
        new WeaponLevelData("DumDum IV","Pierce Ammunition //TODO"),
        new WeaponLevelData("DumDum V","FULL POWER!"),
    };

    public override void Trigger()
    {
        Shoot();
        if(level >= 3)
            Shoot();
    }

    void Shoot()
    {
        Projectile projectileInstance = projectilePrefab.BuildNew(owner, owner.transform.position, Quaternion.identity);
        projectileInstance.Damage = damage;
        BasicShooting(projectileInstance);
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

    protected override void DoOnLevelUp(int level)
    {
        if (level == 2)
            cooldownSecs -= lv2CooldownReduction;

        if (level == 5)
            cooldownSecs -= lv5CooldownReduction;
    }
}
