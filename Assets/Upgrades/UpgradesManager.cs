using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    UpgradeData[] upgradesData;

    public void StartNewUpgradeProcess() 
    {
        UpgradeData[] selectedUpgrades;
        //TODO Logica para seleccionar que upgrades mostrar. PLACEHOLDER:
        Provider.UpgradesView.Show(upgradesData[0], upgradesData[1], upgradesData[2]);
        PauseGameplay();
    }

    void PauseGameplay()
    {
        Provider.Spaceship.GetComponent<SpaceshipMovement>().enabled = false;
        Provider.Spaceship.GetComponent<SpaceshipWeaponsManager>().enabled = false;
        Provider.Spaceship.GetComponent<Lifeform>().enabled = false;
    }

    void UnPauseGame()
    {
        Provider.Spaceship.GetComponent<SpaceshipMovement>().enabled = true;
        Provider.Spaceship.GetComponent<SpaceshipWeaponsManager>().enabled = true;
        Provider.Spaceship.GetComponent<Lifeform>().enabled = true;
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
        UnPauseGame();
    }
}
