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

    private void Start()
    {
        //var stage = Stages.Stage1();
        //stage.Run();
        Provider.SpawnManager.IncreaseSpawner(EnemyId.Alien1, 3);
        Provider.SpawnManager.IncreaseSpawner(EnemyId.Alien1, 1);
    }

    private void Update()
    {
        //TODO ONLY FOR TESTING
        if (Input.GetKeyDown(KeyCode.Q))
            Provider.UpgradesManager.StartNewUpgradeProcess();
    }
}
