using System.Collections.Generic;
using UnityEngine;

public class SpaceshipWeaponsManager : MonoBehaviour
{
    [SerializeField] List<Weapon> weaponsPrefab;
    List<Weapon> weaponsInstances = new List<Weapon>();
    bool autoshooting;

    private void Awake()
    {
        foreach (Weapon weapon in weaponsPrefab)
            SpawnWeapon(weapon);
    }

    public List<UpgradeData> GetAllWeaponsUpgrades()
    {
        List<UpgradeData> upgrades = new List<UpgradeData>();
        foreach (Weapon weapon in weaponsInstances)
        {
            if(weapon.nextUpgrade != null)
            {
                var upgrade = new UpgradeData(weapon.Title, weapon.Desc, weapon.Icon, weaponPrefab: weapon);
                upgrades.Add(upgrade);
            }
        }
        return upgrades;
    }

    public void SpawnWeapon(Weapon weapon)
    {
        var instance = Instantiate(weapon, transform);
        instance.Init(gameObject);
        weaponsInstances.Add(instance);

        if (autoshooting)
            instance.StartAutoshooting();
    }

    public void StartAutoshooting()
    {
        autoshooting = true;
        foreach (Weapon weapon in weaponsInstances)
            weapon.StartAutoshooting();
    }

    public void StopAutoshooting()
    {
        autoshooting = false;
        foreach (Weapon weapon in weaponsInstances)
            weapon.StopAutoshooting();
    }
}
