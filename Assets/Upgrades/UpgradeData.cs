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
    public string title;
    public string description;
    public Sprite icon;
    public Upgrade upgrade;
}
