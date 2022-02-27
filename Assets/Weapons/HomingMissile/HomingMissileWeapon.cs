using UnityEngine;

public class HomingMissileWeapon : Weapon 
{    
    [SerializeField] Projectile projectile;

    public override void Trigger()
    {
        ShootMissile();
        if (HasUpgrade(WeaponUpgrade.Homming_DoubleShoot))
            ShootMissile();
    }

    void ShootMissile()
    {
        Quaternion rotation = Random.rotation;
        rotation.y = 0f;
        rotation.x = 0f;
        //Quaternion rotation = Quaternion.Euler(0,0,Random.Range(45,-45));

        Vector2 spawnPosition = owner.transform.position;
        projectile.BuildNew(owner, spawnPosition, rotation);
    }
}