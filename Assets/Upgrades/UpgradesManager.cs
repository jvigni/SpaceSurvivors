using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    List<Upgrade> upgradesData;

    public void StartNewUpgradeProcess() 
    {
        Upgrade[] selectedUpgrades;
        //TODO Logica para seleccionar que upgrades mostrar. PLACEHOLDER:
        Provider.UpgradesView.Show(upgradesData);
        Provider.App.PauseGameplay();
    }

    private void Awake()
    {
        Provider.UpgradesManager = this;
    }

    private void Start()
    {
        //upgradesData = Resources.LoadAll<UpgradeData>("");
        upgradesData = Provider.Spaceship.GetComponent<SpaceshipWeaponsManager>().GetAllWeaponsUpgrades();
        Provider.UpgradesView.OnUpgradePicked += data => OnUpgradePicked(data);
    }

    void OnUpgradePicked(Upgrade upgrade)
    {
        upgrade.Trigger();
        Provider.App.UnpauseGameplay();
    }
}
