using UnityEngine;

public class FireballWeapon : Weapon {

    [SerializeField] Projectile projectile;
    [SerializeField] float throwForce;
    
    public override void Trigger()
    {
        Vector2 actorPosition = owner.transform.position;
        var target = Provider.Spaceship.NearestEnemy;
        if (target == null) return;
        Vector2 direction = (target.transform.position - owner.transform.position).normalized;
        Vector2 spawnPosition = actorPosition;

        Projectile projectileInstance = projectile.BuildNew(spawnPosition, owner);
        projectileInstance.Push(direction, throwForce);
    }
}
