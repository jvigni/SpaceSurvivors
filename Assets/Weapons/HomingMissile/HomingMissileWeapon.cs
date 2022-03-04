using UnityEngine;

public class HomingMissileWeapon : Weapon 
{
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] int damage = 2;
    [SerializeField] int amountOfProjectiles = 1;
    [SerializeField] float AOERadius = 0f;

    protected override WeaponLevelData[] levelsData => new WeaponLevelData[]
    {
        new WeaponLevelData("Homming I", "bum bum"),
        new WeaponLevelData("Homming II", "advanced bum bum"),
        new WeaponLevelData("Homming III", "uwu"),
        new WeaponLevelData("Homming IV", "uwu"),
        new WeaponLevelData("Homming V", "uwu"),
    };

    public override void Trigger()
    {
        for (int i = 0; i < level; i++)
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
