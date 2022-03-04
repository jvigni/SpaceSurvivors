using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "UpgradeData")]
public class UpgradeData : ScriptableObject
{
    public string title;
    public string description;
    public Sprite icon;
    //public Upgrade upgrade;
    public Weapon weaponPrefab;

}
