using UnityEngine;

[CreateAssetMenu(fileName = "WeaponUpgradeData")]
public class WeaponUpgradeData : ScriptableObject
{
    [SerializeField] string title;
    [SerializeField] string description;
    [SerializeField] Sprite icon;
    [SerializeField] WeaponUpgrade upgrade;
}
