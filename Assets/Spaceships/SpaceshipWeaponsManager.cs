using System.Collections.Generic;
using UnityEngine;

public class SpaceshipWeaponsManager : MonoBehaviour
{
    List<Weapon> weapons = new List<Weapon>();

    public void LoadWeapon(Weapon weapon)
    {
        weapons.Add(weapon);
    }

    public void TurnWeaponsOn()
    {
        foreach (Weapon weapon in weapons)
            weapon.TurnOn();
    }
}
