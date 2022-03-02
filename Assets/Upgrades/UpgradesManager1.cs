using System.Collections.Generic;
using UnityEngine;

public class UpgradeData2
{
    public string Title;
    public string Description;
    public Sprite Icon;
    public Upgrade Upgrade;
    public Weapon WeaponPrefab;


    public UpgradeData2(string title, string description, Sprite icon)
    {
        Title = title;
        Description = description;
        Icon = icon;
    }

    public UpgradeData2 WithWeapon(Weapon weaponPrefab)
    {
        WeaponPrefab = weaponPrefab;
        return this;
    }

    public UpgradeData2 WithUpgrade(Upgrade upgrade)
    {
        Upgrade = upgrade; 
        return this;
    }

    /*
    public UpgradeData2 Requires(Weapon weapon)
    {

    }*/
}

public class UpgradesManager1 : MonoBehaviour
{
    [SerializeField] Weapon flamethrower;
    [SerializeField] Weapon hommingMissiles;
    [SerializeField] Weapon rpg;
    [SerializeField] Weapon dumdum;

    List<UpgradeData2> upgrades;

    private void Start()
    {
        LoadUpgrade("Flamethrower", "Burn them all!", "FlamethrowerIcon")
            .WithWeapon(flamethrower);

        LoadUpgrade("RPG", "Rpg weapon", "RpgIcon")
            .WithWeapon(rpg);

        LoadUpgrade("Homming Missiles", "+Weapon", "HommingMissilesIcon")
            .WithWeapon(hommingMissiles);
        LoadUpgrade("Dual Launcher", "Shoots 2 Homming missiles at once", "HommingDualLauncherIcon")
            .WithUpgrade(Upgrade.Homming_DoubleShoot);
        
        LoadUpgrade("DumDum", "Weapon", "DumDumIcon")
            .WithWeapon(dumdum);
        LoadUpgrade("Automatic Turret", "DumDum now autotargets enemies", "DumDumAutoTurretIcon")
            .WithUpgrade(Upgrade.DumDum_TargetedAim);
        
    }

    UpgradeData2 LoadUpgrade(string title, string description, string iconFileName)
    {
        var icon = Resources.Load<Sprite>(iconFileName);
        var upgrade = new UpgradeData2(title, description, icon);
        upgrades.Add(upgrade);
        return upgrade;
    }
}