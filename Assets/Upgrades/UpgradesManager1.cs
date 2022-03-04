using System.Collections.Generic;
using UnityEngine;

/*
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
}*/