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
        Provider.UpgradesView.OnUpgradePicked += data => OnUpgradePicked(data);
    }

    void OnUpgradePicked(UpgradeData data)
    {
        if(data.upgrade != Upgrade.None)
            Provider.Spaceship.GetComponent<SpaceshipUpgradesManager>().AddUpgrade(data.upgrade);
        if (data.weaponPrefab != null)
            Provider.Spaceship.GetComponent<SpaceshipWeaponsManager>().SpawnWeapon(data.weaponPrefab);

        Provider.App.UnpauseGameplay();
    }
}
