using System.Collections;
using UnityEngine;

public class CannonWeapon : Weapon 
{
    [SerializeField] int damage;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float throwForce;
    [SerializeField] float lv3CooldownRed;
    [SerializeField] float lv5CooldownRed;
    [SerializeField] float timeBetweenShoots;
    int amountOfShoots = 1;

    public override WeaponID ID => WeaponID.Cannon;
    protected override WeaponLevelData[] levelsData => new WeaponLevelData[]
    {
        new WeaponLevelData("New Weapon: <color=orange>Cannon I","Shoots Huge Projectiles"),
        new WeaponLevelData("Cannon II","Shoots 2 Bullets"),
        new WeaponLevelData("Cannon III","Increased Rate of Fire"),
        new WeaponLevelData("Cannon IV","Shoots 3 Bullets"),
        new WeaponLevelData("Cannon V","Full Power!"),
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

        var projectile = Instantiate(projectilePrefab, owner.transform.position, Quaternion.identity);
        var projectileHit = projectile.GetComponent<ProjectileHit>();
        projectileHit.Damage = damage;
        Vector2 direction = (target.transform.position - owner.transform.position).normalized;
        var projectileMovement = projectile.GetComponent<ProjectileMovement>();
        projectileMovement.RotateTowards(target.transform);
        projectileMovement.Push(direction, throwForce);
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
