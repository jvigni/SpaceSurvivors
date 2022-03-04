using UnityEngine;

public class HomingMissileWeapon : Weapon 
{
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] int damage;
    [SerializeField] float lv3CooldownDecrement;
    [SerializeField] float lv5AOERadius;

    protected override WeaponLevelData[] levelsData => new WeaponLevelData[]
    {
        new WeaponLevelData("Homming Missile I", "Shoots self guided missiles"),
        new WeaponLevelData("Homming Missile II", "Shoots 2 missiles at once"),
        new WeaponLevelData("Homming Missile III", "Rate of fire greatly increased"),
        new WeaponLevelData("Homming Missile IV", "Shoots 3 missiles at once"),
        new WeaponLevelData("Homming Missile V", "Missiles goes BOOM"),
    };

    public override void Trigger()
    {
        var amountOfMissiles = 1;
        if (level >= 2)
            amountOfMissiles = 2;
        if (level >= 4)
            amountOfMissiles = 3;

        for (int i = 0; i < amountOfMissiles; i++)
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
        if(level == 5)
            projInstance.AOERadius = lv5AOERadius;
    }
}
