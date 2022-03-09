using System.Collections;
using UnityEngine;

public class App : MonoBehaviour
{
    [SerializeField] GameObject spaceship;
    [SerializeField] UpgradesView upgradesView;

    public void UnpauseGameplay()
    {
        Time.timeScale = 1;
    }

    public void PauseGameplay()
    {
        Time.timeScale = 0;
    }

    private void Awake()
    {
        Provider.App = this;
        Provider.Spaceship = spaceship;
        Provider.UpgradesView = upgradesView;
    }

    private void Update()
    {
        //TODO ONLY FOR TESTING
        if (Input.GetKeyDown(KeyCode.Q))
            Provider.UpgradesManager.StartNewUpgradeProcess();
    }
}
