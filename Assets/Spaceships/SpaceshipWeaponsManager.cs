using System.Collections.Generic;
using UnityEngine;

public class SpaceshipWeaponsManager : MonoBehaviour
{
    [SerializeField] List<Weapon> weaponsPrefab;
    List<Weapon> weaponsInstances = new List<Weapon>();

    private void Start()
    {
        foreach (Weapon weapon in weaponsPrefab)
            SpawnWeapon(weapon);
    }

    public void SpawnWeapon(Weapon weapon)
    {
        var instance = Instantiate(weapon);
        instance.Init(GetComponent<Lifeform>());
        weaponsInstances.Add(instance);
    }

    public void TurnAutoshootOn()
    {
        foreach (Weapon weapon in weaponsInstances)
            weapon.StartAutoshooting();
    }

    public void TurnAutoshootOff()
    {
        foreach (Weapon weapon in weaponsInstances)
            weapon.StopAutoshooting();
    }
}
