using System.Collections.Generic;
using UnityEngine;

public class SpaceshipWeaponsManager : MonoBehaviour
{
    [SerializeField] List<Weapon> weaponsPrefab;
    List<Weapon> weaponsInstances = new List<Weapon>();
    List<WeaponUpgrade> upgrades = new List<WeaponUpgrade>();

    private void Awake()
    {
        foreach (Weapon weapon in weaponsPrefab)
            SpawnWeapon(weapon);
    }

    public void SpawnWeapon(Weapon weapon)
    {
        var instance = Instantiate(weapon);
        instance.Init(gameObject);
        instance.transform.parent = transform;
        weaponsInstances.Add(instance);
    }

    public void StartAutoshooting()
    {
        foreach (Weapon weapon in weaponsInstances)
            weapon.StartAutoshooting();
    }

    public void StopAutoshooting()
    {
        foreach (Weapon weapon in weaponsInstances)
            weapon.StopAutoshooting();
    }

    public void AddUpgrade(WeaponUpgrade upgrade) => upgrades.Remove(upgrade);
    public bool HasUpgrade(WeaponUpgrade upgrade) => upgrades.Contains(upgrade);
}
