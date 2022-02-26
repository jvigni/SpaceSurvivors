using UnityEngine;

public class RpgWeapon : Weapon
{
    [SerializeField] Projectile projectile;
    [SerializeField] float throwForce;

    public override void Trigger()
    {
        var target = Provider.Spaceship.GetComponent<Targeting>().Target;
        if (target == null)
            return;

        Projectile projectileInstance = projectile.BuildNew(owner, owner.transform.position, Quaternion.identity);
        Vector2 direction = owner.transform.up;
        projectileInstance.Push(direction, throwForce);
    }
}
