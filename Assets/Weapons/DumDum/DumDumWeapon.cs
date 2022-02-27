using UnityEngine;

public class DumDumWeapon : Weapon
{
    [SerializeField] float offset;
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] float throwForce;

    public override void Trigger()
    {
        Projectile projectileInstance = projectilePrefab.BuildNew(owner, owner.transform.position, Quaternion.identity);
        if (HasUpgrade(Upgrade.DumDum_TargetedAim))
            TargetedShooting(projectileInstance);
        else
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
}
