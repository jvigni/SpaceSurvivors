using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipWeaponsManager : MonoBehaviour
{
    [SerializeField] List<Weapon> weaponsPrefab;
    List<Weapon> weaponsInstances = new List<Weapon>();
    Coroutine autoshootingRoutine;

    private void Start()
    {
        foreach (Weapon weapon in weaponsPrefab)
            SpawnWeapon(weapon);
    }

    public void SpawnWeapon(Weapon weapon)
    {
        var instance = Instantiate(weapon);
        instance.Init(GetComponent<Lifeform>());
        instance.transform.parent = transform;
        weaponsInstances.Add(instance);
    }

    public void TurnAutoshootOn()
    {
        var autoshootingRoutine = StartCoroutine(AutoshootingRoutine());
    }

    public void TurnAutoshootOff()
    {
        StopCoroutine(autoshootingRoutine);
    }

    IEnumerator AutoshootingRoutine()
    {
        var time = .01f;
        var wfs = new WaitForSecondsRealtime(time);
        while (true)
        {
            yield return wfs;
            foreach (Weapon weapon in weaponsInstances)
                weapon.ReduceCooldown(time);
        }
    }
}
