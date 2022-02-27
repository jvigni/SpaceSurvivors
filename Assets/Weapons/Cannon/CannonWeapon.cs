using UnityEngine;

public class CannonWeapon : Weapon 
{
    [SerializeField] Projectile projectile;
    [SerializeField] float throwForce;
    
    public override void Trigger()
    {
        var target = Provider.Spaceship.GetComponent<Targeting>().Target;
        if (target == null) 
            return;

        Projectile projectileInstance = projectile.BuildNew(owner, owner.transform.position, Quaternion.identity);
        Vector2 direction = (target.transform.position - owner.transform.position).normalized;
        if (HasUpgrade(Upgrade.Cannon_pierce))
            projectileInstance.Pierce = true;

        projectileInstance.Push(direction, throwForce);
    }
}
