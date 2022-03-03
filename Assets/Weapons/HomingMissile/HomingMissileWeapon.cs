using UnityEngine;

public class HomingMissileWeapon : Weapon 
{    
    [SerializeField] Projectile projectile;

    public override void Trigger()
    {
        ShootMissile();
        if (level >= 2)
            ShootMissile();
        if (level >= 3)
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

public class HommingMissileLv1 : Weapon
{
    [SerializeField] Projectile projectile;

    protected override string Title => "Homming Missile I";
    protected override string Description => "Shoots self-guided missiles";
    public override Weapon NextUpgrade => Provider.Weapons.HommingMissileLv2;

    public override void Trigger()
    {
        HommingMissileLogic.ShootMissile(projectile, owner);
    }
}

public class HommingMissileLv2 : Weapon
{
    [SerializeField] Projectile projectile;

    protected override string Title => "Homming Missile II";
    protected override string Description => "Shoots 2 missiles at once";
    public override Weapon NextUpgrade => Provider.Weapons.HommingMissileLv3;
    
    public override void Trigger()
    {
        HommingMissileLogic.ShootMissile(projectile, owner);
        HommingMissileLogic.ShootMissile(projectile, owner);
    }
}

public class HommingMissileLv3 : Weapon
{
    [SerializeField] Projectile projectile;

    protected override string Title => "Homming Missile III";
    protected override string Description => "Highly increase rate of fire";
    public override Weapon NextUpgrade => Provider.Weapons.HommingMissileLv4;

    public override void Trigger()
    {
        HommingMissileLogic.ShootMissile(projectile, owner);
        HommingMissileLogic.ShootMissile(projectile, owner);
    }
}
public class HommingMissileLv4 : Weapon
{
    [SerializeField] Projectile projectile;

    protected override string Title => "Homming Missile IV";
    protected override string Description => "Shoots 3 missiles at once";
    public override Weapon NextUpgrade => Provider.Weapons.HommingMissileLv5;

    public override void Trigger()
    {
        HommingMissileLogic.ShootMissile(projectile, owner);
        HommingMissileLogic.ShootMissile(projectile, owner);
        HommingMissileLogic.ShootMissile(projectile, owner);
    }
}

public class HommingMissileLv5 : Weapon
{
    [SerializeField] Projectile projectile;

    protected override string Title => "Homming Missile V";
    protected override string Description => "Missiles go BOOM!";
    public override Weapon NextUpgrade => null;

    public override void Trigger()
    {
        HommingMissileLogic.ShootMissile(projectile, owner);
        HommingMissileLogic.ShootMissile(projectile, owner);
        HommingMissileLogic.ShootMissile(projectile, owner);
    }
}

public class HommingMissileLogic
{
    public static void ShootMissile(Projectile projectile, GameObject weaponOwner)
    {
        Quaternion rotation = Random.rotation;
        rotation.y = 0f;
        rotation.x = 0f;
        Vector2 spawnPosition = weaponOwner.transform.position;
        projectile.BuildNew(weaponOwner, spawnPosition, rotation);
    }
}