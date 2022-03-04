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

    public void LevelUp(Weapon weapon)
    {
        var index = weaponsInstances.IndexOf(weapon);
        weaponsInstances[index].LevelUp();
    }

    public List<Upgrade> GetAllWeaponsUpgrades()
    {
        List<Upgrade> upgrades = new List<Upgrade>();
        foreach (Weapon weapon in weaponsInstances)
        {
            if(!weapon.IsMaxLevel)
                upgrades.Add(new WeaponLevelUpUpgrade(weapon));
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
