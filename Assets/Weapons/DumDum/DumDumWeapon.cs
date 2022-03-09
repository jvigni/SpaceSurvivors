using System.Collections;
using UnityEngine;

public class DumDumWeapon : Weapon
{
    [SerializeField] int damage;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float throwForce;
    [SerializeField] float lv3CooldownRed;
    [SerializeField] float lv5CooldownRed;
    [SerializeField] float timeBetweenShoots;
    int amountOfShoots = 1;

    public override WeaponID ID => WeaponID.DumDum;
    protected override WeaponLevelData[] levelsData => new WeaponLevelData[]
    {
        new WeaponLevelData("New Weapon: <color=orange>DumDum I","Fast Shooting Weapon"),
        new WeaponLevelData("DumDum II","Shoots 2 Bullets"),
        new WeaponLevelData("DumDum III","Increased Rate of Fire"),
        new WeaponLevelData("DumDum IV","Shoots 3 Bullets"),
        new WeaponLevelData("DumDum V","FULL POWER!"),
    };

    public override IEnumerator DoOnCooldownFinish()
    {
        for (int i = 0; i < amountOfShoots; i++)
        {
            yield return new WaitForSeconds(timeBetweenShoots);
            Shoot();
        }
    }

    void Shoot()
    {
        var target = Provider.Spaceship.GetComponent<Targeting>().Target;
        if (target == null)
            return;

        var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<ProjectileHit>().Damage = damage;
        Vector2 direction = (target.transform.position - owner.transform.position).normalized;
        var ProjMovement = projectile.GetComponent<ProjectileMovement>();
        ProjMovement.RotateTowards(target.transform);
        ProjMovement.Push(direction, throwForce);
    }

    protected override void DoOnLevelUp(int level)
    {
        if (level == 2)
            amountOfShoots += 1;

        if (level == 3)
            Cooldown.Seconds -= lv3CooldownRed;

        if (level == 4)
            amountOfShoots += 1;

        if (level == 5)
            Cooldown.Seconds -= lv5CooldownRed;
    }
}

/*
void BasicShooting(Projectile projectile)
{
    projectile.transform.rotation = Provider.Spaceship.transform.rotation;

    offset *= -1;
    projectile.transform.Translate(Vector3.right * offset);

    Vector2 direction = transform.up;
    projectile.Push(direction, throwForce);
}
*/