using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    [SerializeField] List<Weapon> weaponsPrefab;

    private void Awake()
    {
        Provider.WeaponsManager = this;   
    }
    
    public List<Weapon> GetUnequipedWeapons()
    {
        var unequipedWeapons = new List<Weapon>();
        var equipedWeapons = Provider.Spaceship.GetComponent<SpaceshipWeaponsManager>().EquipedWeapons;
        foreach(Weapon weaponPrefab in weaponsPrefab)
        {
            bool alreadyEquiped = false;
            foreach(Weapon equipedWeapon in equipedWeapons)
            {
                if (weaponPrefab.ID == equipedWeapon.ID)
                    alreadyEquiped = true;
            }
            if (!alreadyEquiped)
                unequipedWeapons.Add(weaponPrefab);
        }
        return unequipedWeapons;
    }
}
