using UnityEngine;

public class HomingMissileWeapon : Weapon 
{
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] int damage = 2;
    [SerializeField] int amountOfProjectiles = 1;
    [SerializeField] float AOERadius = 0f;

    public override void Trigger()
    {
        for (int i = 0; i < amountOfProjectiles; i++)
            ShootMissile();
    }

    void ShootMissile()
    {
        Quaternion rotation = Random.rotation;
        rotation.y = 0f;
        rotation.x = 0f;
        Vector2 spawnPosition = owner.transform.position;
        var projInstance = projectilePrefab.BuildNew(owner, spawnPosition, rotation);
        projInstance.Damage = damage;
        projInstance.AOERadius = AOERadius;
    }
}
