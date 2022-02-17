using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipWeaponsManager : MonoBehaviour
{
    List<Weapon> weapons = new List<Weapon>();
    List<Coroutine> weaponsRoutines = new List<Coroutine>();

    public void LoadWeapon(Weapon weapon)
    {
        weapons.Add(weapon);
    }

    public void TurnWeaponsOn()
    {
        foreach (Weapon weapon in weapons)
        {
            var routine = StartCoroutine(ShootWeaponRoutine(weapon));
            weaponsRoutines.Add(routine);
        }
    }

    public void TurnWeaponsOff()
    {
        foreach (Coroutine routine in weaponsRoutines)
            StopCoroutine(routine);
    }

    IEnumerator ShootWeaponRoutine(Weapon weapon)
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(weapon.CooldownSecs);
            weapon.Trigger();
        }
    }
}
