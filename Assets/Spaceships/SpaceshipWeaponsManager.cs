using System.Collections.Generic;
using UnityEngine;

public class SpaceshipWeaponsManager : MonoBehaviour
{
    [SerializeField] List<Weapon> weaponsPrefab;
    public List<Weapon> EquipedWeapons = new List<Weapon>();
    bool autoshooting;

    private void Awake()
    {
        foreach (Weapon weapon in weaponsPrefab)
            SpawnWeapon(weapon);
    }

    public List<Upgrade> GetAllWeaponsUpgrades()
    {
        List<Upgrade> upgrades = new List<Upgrade>();
        foreach (Weapon weapon in EquipedWeapons)
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
        EquipedWeapons.Add(instance);

        if (autoshooting)
            instance.TurnOn();
    }

    public void StartAutoshooting()
    {
        autoshooting = true;
        foreach (Weapon weapon in EquipedWeapons)
            weapon.TurnOn();
    }

    public void StopAutoshooting()
    {
        autoshooting = false;
        foreach (Weapon weapon in EquipedWeapons)
            weapon.TurnOff();
    }
}
