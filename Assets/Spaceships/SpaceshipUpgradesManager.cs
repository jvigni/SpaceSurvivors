using System.Collections.Generic;
using UnityEngine;

public class SpaceshipUpgradesManager : MonoBehaviour
{
    List<Upgrade> upgrades = new List<Upgrade>();

    public void AddUpgrade(Upgrade upgrade) => upgrades.Remove(upgrade);
    public bool HasUpgrade(Upgrade upgrade) => upgrades.Contains(upgrade);
}
