using UnityEngine;

public class FireballWeapon : Weapon 
{
    [SerializeField] Projectile projectile;
    [SerializeField] float throwForce;
    
    public override void Trigger()
    {
        var target = Provider.Spaceship.GetComponent<Targeting>().Target;
        if (target == null) 
            return;

        Debug.Log("2");
        Projectile projectileInstance = projectile.BuildNew(owner.transform.position, owner);
        Vector2 direction = (target.transform.position - owner.transform.position).normalized;
        projectileInstance.Push(direction, throwForce);
    }
}
