using UnityEngine;
using UnityEngine.UI;

public enum Upgrade
{
    Cannon_pierce,
    Homming_DoubleShoot
}

[CreateAssetMenu(fileName = "UpgradeData")]
public class UpgradeData : ScriptableObject
{
    [SerializeField] string title;
    [SerializeField] string description;
    [SerializeField] Sprite icon;
    [SerializeField] Upgrade upgrade;
}
