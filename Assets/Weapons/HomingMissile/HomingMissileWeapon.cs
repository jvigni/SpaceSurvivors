using UnityEngine;

public class HomingMissileWeapon : Weapon 
{    
    [SerializeField] Projectile projectile;

    public override Weapon NextUpgrade => throw new System.NotImplementedException();
    protected override string Title => throw new System.NotImplementedException();
    protected override string Description => throw new System.NotImplementedException();

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
    HommingMissileLauncher missileLauncher;

    protected override string Title => "Homming Missile I";
    protected override string Description => "Shoots self-guided missiles";
    public override Weapon NextUpgrade => Provider.WeaponsManager.HommingMissileLv2;

    private void Start()
    {
        missileLauncher = GetComponent<HommingMissileLauncher>();
    }

    public override void Trigger()
    {
        missileLauncher.ShootMissile(owner);
    }
}

public class HommingMissileLv2 : Weapon
{
    HommingMissileLauncher missileLauncher;

    protected override string Title => "Homming Missile II";
    protected override string Description => "Shoots 2 missiles at once";
    public override Weapon NextUpgrade => Provider.WeaponsManager.HommingMissileLv3;

    private void Start()
    {
        missileLauncher = GetComponent<HommingMissileLauncher>();
    }

    public override void Trigger()
    {
        missileLauncher.ShootMissile(owner);
        missileLauncher.ShootMissile(owner);
    }
}

public class HommingMissileLv3 : Weapon
{
    HommingMissileLauncher missileLauncher;

    protected override string Title => "Homming Missile III";
    protected override string Description => "Highly increase rate of fire";
    public override Weapon NextUpgrade => Provider.WeaponsManager.HommingMissileLv4;

    private void Start()
    {
        missileLauncher = GetComponent<HommingMissileLauncher>();
    }

    public override void Trigger()
    {
        missileLauncher.ShootMissile(owner);
        missileLauncher.ShootMissile(owner);
    }
}

public class HommingMissileLv4 : Weapon
{
    HommingMissileLauncher missileLauncher;

    protected override string Title => "Homming Missile IV";
    protected override string Description => "Shoots 3 missiles at once";
    public override Weapon NextUpgrade => Provider.WeaponsManager.HommingMissileLv5;

    private void Start()
    {
        missileLauncher = GetComponent<HommingMissileLauncher>();
    }

    public override void Trigger()
    {
        missileLauncher.ShootMissile(owner);
        missileLauncher.ShootMissile(owner);
        missileLauncher.ShootMissile(owner);
    }
}

public class HommingMissileLv5 : Weapon
{
    HommingMissileLauncher missileLauncher;

    protected override string Title => "Homming Missile V";
    protected override string Description => "Missiles go BOOM!";
    public override Weapon NextUpgrade => null;

    private void Start()
    {
        missileLauncher = GetComponent<HommingMissileLauncher>();
    }

    public override void Trigger()
    {
        missileLauncher.ShootMissile(owner);
        missileLauncher.ShootMissile(owner);
        missileLauncher.ShootMissile(owner);
    }
}

public class HommingMissileLauncher : MonoBehaviour
{
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] int damage = 2;
    [SerializeField] float AOERadius = 0f;

    public void ShootMissile(GameObject weaponOwner)
    {
        Quaternion rotation = Random.rotation;
        rotation.y = 0f;
        rotation.x = 0f;
        Vector2 spawnPosition = weaponOwner.transform.position;
        var projInstance = projectilePrefab.BuildNew(weaponOwner, spawnPosition, rotation);
        projInstance.Damage = damage;
        projInstance.AOERadius = AOERadius;
    }
}