using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade
{
    public abstract void Trigger();
    public abstract UpgradeData2 Data { get; }
}

public class NewWeaponUpgrade : Upgrade
{
    Weapon weaponPrefab;

    public NewWeaponUpgrade(Weapon weaponPrefab)
    {
        this.weaponPrefab = weaponPrefab;
    }

    public override UpgradeData2 Data => new UpgradeData2(weaponPrefab.Title, weaponPrefab.Desc, weaponPrefab.Icon);

    public override void Trigger()
    {
        Provider.Spaceship.GetComponent<SpaceshipWeaponsManager>().SpawnWeapon(weaponPrefab);
    }
}

public class WeaponLevelUpUpgrade : Upgrade
{
    Weapon weapon;

    public WeaponLevelUpUpgrade(Weapon weapon)
    {
        this.weapon = weapon;
    }

    public override UpgradeData2 Data => 
        new UpgradeData2(weapon.NextLevelData.title, weapon.NextLevelData.desc, weapon.Icon);

    public override void Trigger()
    {
        Provider.Spaceship.GetComponent<SpaceshipWeaponsManager>().LevelUp(weapon);
    }
}



public class UpgradesView : MonoBehaviour
{
    [SerializeField] UpgradeView[] upgradeViews;
    public event Action<UpgradeData> OnUpgradePicked;
    int selectedIndex;

    public void Show(List<UpgradeData> upgradeData)
    {
        for (int i = 0; i < upgradeViews.Length; i++)
            upgradeViews[i].Init(upgradeData[i]);

        Select(0);
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        var upInput = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W);
        if (upInput && selectedIndex != 0)
            Select(selectedIndex - 1);

        var downInput = Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S);
        if (downInput && selectedIndex != 2)
            Select(selectedIndex + 1);
        
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.F))
        {
            OnUpgradePicked?.Invoke(upgradeViews[selectedIndex].Data);
            Hide();
        }
    }

    void Select(int index)
    {
        upgradeViews[selectedIndex].SetSelected(false);

        selectedIndex = index;
        upgradeViews[index].SetSelected(true);
    }
}
