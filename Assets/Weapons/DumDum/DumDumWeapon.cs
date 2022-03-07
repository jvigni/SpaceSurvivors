using System.Collections;
using UnityEngine;

public class DumDumWeapon : Weapon
{
    [SerializeField] int damage;
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] float throwForce;
    [SerializeField] float lv3CooldownReductionCoef;
    [SerializeField] float lv5CooldownReductionCoef;

    static float timeBetweenShoots = .2f;
    WaitForSeconds wfsBetwenShoots = new WaitForSeconds(timeBetweenShoots);
    int amountOfShoots = 1;

    public override WeaponID ID => WeaponID.DumDum;
    protected override WeaponLevelData[] levelsData => new WeaponLevelData[]
    {
        new WeaponLevelData("New Weapon: <color=orange>DumDum","Fast shooting weapon"),
        new WeaponLevelData("DumDum II","Shoots 2 bullets"),
        new WeaponLevelData("DumDum III","Increased rate of fire"),
        new WeaponLevelData("DumDum IV","Shoots 3 bullets"),
        new WeaponLevelData("DumDum V","FULL POWER!"),
    };

    public override IEnumerator DoOnCooldownFinish()
    {
        for (int i = 0; i < amountOfShoots; i++)
        {
            yield return wfsBetwenShoots;
            Debug.Log("SHOOT!");
            Shoot();
        }
    }

    void Shoot()
    {
        var target = Provider.Spaceship.GetComponent<Targeting>().Target;
        if (target == null)
            return;

        Projectile projectile = projectilePrefab.BuildNew(owner, owner.transform.position, Quaternion.identity);
        projectile.Damage = damage;
        Vector2 direction = (target.transform.position - owner.transform.position).normalized;
        projectile.RotateTowards(target.transform);
        projectile.Push(direction, throwForce);
    }

    protected override void DoOnLevelUp(int level)
    {
        if (level == 2)
            amountOfShoots += 1;

        if (level == 3)
            Cooldown.Seconds -= Cooldown.Seconds * lv3CooldownReductionCoef;

        if (level == 4)
            amountOfShoots += 1;

        if (level == 5)
            Cooldown.Seconds -= timeBetweenShoots * amountOfShoots;
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