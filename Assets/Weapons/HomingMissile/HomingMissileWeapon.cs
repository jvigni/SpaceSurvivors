using System.Collections;
using UnityEngine;

public class HomingMissileWeapon : Weapon 
{
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] int damage;
    [SerializeField] float lv3CooldownDecrementCoef;
    [SerializeField] float lv5AOERadius;

    public override WeaponID ID => WeaponID.HommingMissile;
    protected override WeaponLevelData[] levelsData => new WeaponLevelData[]
    {
        new WeaponLevelData("New Weapon: <color=orange>Homming Missiles", "Shoots self guided missiles"),
        new WeaponLevelData("Homming Missiles II", "Shoots 2 missiles at once"),
        new WeaponLevelData("Homming Missiles III", "Rate of fire greatly increased"),
        new WeaponLevelData("Homming Missiles IV", "Shoots 3 missiles at once"),
        new WeaponLevelData("Homming Missiles V", "Missiles goes BOOM"),
    };

    public override IEnumerator OnCooldownFinish()
    {
        var amountOfMissiles = 1;
        if (level >= 2)
            amountOfMissiles = 2;
        if (level >= 4)
            amountOfMissiles = 3;

        for (int i = 0; i < amountOfMissiles; i++)
            ShootMissile();

        yield return null;
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

    protected override void DoOnLevelUp(int level)
    {
        if (level == 3)
            Cooldown.Seconds *= lv3CooldownDecrementCoef;
    }
}
