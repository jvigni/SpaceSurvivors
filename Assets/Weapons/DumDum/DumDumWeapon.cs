using UnityEngine;

public class DumDumWeapon : Weapon
{
    [SerializeField] float offset;
    [SerializeField] Projectile projectile;
    [SerializeField] float throwForce;

    public override void Trigger()
    {
        Projectile projectileInstance = projectile.BuildNew(owner, owner.transform.position, Quaternion.identity);
        
        projectileInstance.transform.rotation = Provider.Spaceship.transform.rotation;

        offset *= -1;
        projectileInstance.transform.Translate(Vector3.right * offset);

        Vector2 direction = transform.up;
        projectileInstance.Push(direction, throwForce);
    }
}
