using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    private void Awake()
    {
        Provider.UpgradesManager = this;
    }

    private void Start()
    {
        Provider.UpgradesView.OnUpgradePicked += data => OnUpgradePicked(data);
    }

    public void StartNewUpgradeProcess()
    {
        List<Upgrade> posibleUpgrades = new List<Upgrade>();
        posibleUpgrades.AddRange(GetLevelUpUpgrades());
        posibleUpgrades.AddRange(GetNewWeaponsUpgrades());
        posibleUpgrades.Shuffle();

        Provider.UpgradesView.Show(posibleUpgrades[0], posibleUpgrades[1], posibleUpgrades[2]);
        Provider.App.PauseGameplay();
    }

    List<Upgrade> GetLevelUpUpgrades()
    {
        List<Upgrade> upgrades = new List<Upgrade>();
        var equipedWeapons = Provider.Spaceship.GetComponent<SpaceshipWeaponsManager>().EquipedWeapons;
        foreach (Weapon equipedWeapon in equipedWeapons)
        {
            if (!equipedWeapon.IsMaxLevel)
                upgrades.Add(new WeaponLevelUpUpgrade(equipedWeapon));
        }
        return upgrades;
    }

    List<Upgrade> GetNewWeaponsUpgrades()
    {
        List<Upgrade> upgrades = new List<Upgrade>();
        var unequipedWeapons = Provider.WeaponsManager.GetUnequipedWeapons();
        foreach (Weapon unequipedWeapon in unequipedWeapons)
            upgrades.Add(new NewWeaponUpgrade(unequipedWeapon));
        return upgrades;
    }

    void OnUpgradePicked(Upgrade upgrade)
    {
        upgrade.Trigger();
        Provider.App.UnpauseGameplay();
    }
}
