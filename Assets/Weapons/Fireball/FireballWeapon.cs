using UnityEngine;

public class FireballWeapon : Weapon {

    public Projectile projectile;
    public float throwForce;
    public float secondsBetweenShoots;
    private Cooldown rateOfFireCooldown;

    public FireballWeapon() : base(1) { }

    public override void Trigger()
    {
        Vector2 actorPosition = owner.transform.position;
        var target = Provider.Spaceship.NearestEnemy;
        Vector2 direction = (target.transform.position - owner.transform.position).normalized;
        //Vector2 direction = owner.GetComponent<PlayerAiming>().MousePositionRelativeToPlayer().normalized;
        Vector2 spawnPosition = actorPosition;// + direction;

        Projectile projectileInstance = projectile.BuildNew(spawnPosition, owner);
        projectileInstance.Push(direction, throwForce);
        rateOfFireCooldown.Start();
    }
}
