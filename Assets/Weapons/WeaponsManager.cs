using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    public Weapon HommingMissiles;
    public Weapon DumDum;
    public Weapon Cannon;
    public Weapon Flamethrower;
    public Weapon Rpg;

    private void Awake()
    {
        Provider.WeaponsManager = this;   
    }


}
