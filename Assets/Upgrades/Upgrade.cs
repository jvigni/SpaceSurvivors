using UnityEngine;

public abstract class Upgrade
{
    public string Title;
    public string Description;
    public Sprite Icon;

    public Upgrade(string title, string desc, Sprite icon)
    {
        Title = title;
        Description = desc;
        Icon = icon;
    }

    public abstract void Trigger();
}

public class NewWeaponUpgrade : Upgrade
{
    Weapon weapon;

    public NewWeaponUpgrade(Weapon weapon)
        : base(weapon.FirstLevelData.Title, weapon.FirstLevelData.Desc, weapon.Icon)
    {
        this.weapon = weapon;
    }

    public override void Trigger()
    {
        Provider.Spaceship.GetComponent<SpaceshipWeaponsManager>().SpawnWeapon(weapon);
    }
}

public class WeaponLevelUpUpgrade : Upgrade
{
    Weapon weapon;

    public WeaponLevelUpUpgrade(Weapon weapon) 
        : base(weapon.NextLevelData.Title, weapon.NextLevelData.Desc, weapon.Icon)
    {
        this.weapon = weapon;
    }

    public override void Trigger()
    {
        Provider.Spaceship.GetComponent<SpaceshipWeaponsManager>().LevelUp(weapon);
    }
}