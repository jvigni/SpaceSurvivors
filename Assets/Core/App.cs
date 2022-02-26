using System.Collections;
using UnityEngine;

public class App : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] GameObject spaceship;
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] EnemyBlueprint selectedEnemyBlueprint;
    [SerializeField] GameObject alien1;

    private void Awake()
    {
        Provider.Spaceship = spaceship;    
    }

    private void Start()
    {
        //InstantiateSpaceship();

        StartCoroutine(SpawnEnemies());

        var weaponsManager = Provider.Spaceship.GetComponent<SpaceshipWeaponsManager>();
        weaponsManager.StartAutoshooting();
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            var waitSeconds = Random.Range(.5f, 2f);
            var wfs = new WaitForSecondsRealtime(waitSeconds);
            yield return wfs;

            var amountToSpawn = Random.Range(1, 6);
            for (int i = 0; i < amountToSpawn; i++)
                SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        float minRadius = 20f;
        float radius = minRadius + Random.Range(0f, 10f);
        float angle = Random.Range(0, 359);
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        var spawnPos = Provider.Spaceship.transform.position + new Vector3(x, y);

        //Enemy enemyInstance = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        //enemyInstance.Init(selectedEnemyBlueprint);
        Instantiate(alien1, spawnPos, Quaternion.identity);
    }
}
