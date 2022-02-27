using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    UpgradeData[] upgradesData;

    public void StartNewUpgradeProcess() 
    {
        UpgradeData[] selectedUpgrades;
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
        upgradesData = Resources.LoadAll<UpgradeData>("");
        Provider.UpgradesView.OnUpgradePicked += upgrade => OnUpgradePicked(upgrade);
    }

    void OnUpgradePicked(Upgrade upgrade)
    {
        Provider.Spaceship.GetComponent<SpaceshipUpgradesManager>().AddUpgrade(upgrade);
        Provider.App.UnpauseGameplay();
    }
}
