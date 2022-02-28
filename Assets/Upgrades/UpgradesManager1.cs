using System.Collections.Generic;
using UnityEngine;

public class UpgradeData2
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string IconFileName { get; private set; }
    public Upgrade Upgrade { get; private set; }
    public Weapon WeaponPrefab { get; private set; }

    public UpgradeData2(string title, string description, string iconFileName)
    {
        Title = title;
        Description = description;
        IconFileName = iconFileName;
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
}

public class UpgradesManager1 : MonoBehaviour
{
    [SerializeField] Weapon flamethrower;

    List<UpgradeData2> upgrades;

    private void Start()
    {
        LoadUpgrade("Flamethrower", "Burn them all!", "FlamethrowerIcon")
            .WithWeapon(flamethrower);
        LoadUpgrade("Automatic Turret", "DumDum now autotargets enemies", "DumDumAutoTurretIcon")
            .WithUpgrade(Upgrade.DumDum_TargetedAim);
        LoadUpgrade("Dual Launcher", "Shoots 2 Homming missiles at once", "HommingDualLauncherIcon");
    }

    UpgradeData2 LoadUpgrade(string title, string description, string iconFileName)
    {
        var upgrade = new UpgradeData2(title, description, iconFileName);
        upgrades.Add(upgrade);
        return upgrade;
    }
}