using System.Collections;
using UnityEngine;

public class App : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] EnemyBlueprint selectedEnemyBlueprint;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());

        var weaponsManager = Provider.Spaceship.GetComponent<SpaceshipWeaponsManager>();
        weaponsManager.LoadWeapon(new LaserTurretWeapon());
        weaponsManager.TurnWeaponsOn();
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            var waitSeconds = Random.Range(.5f, 2f);
            var wfs = new WaitForSecondsRealtime(waitSeconds);
            yield return wfs;

            var amountToSpawn = Random.Range(4, 10);
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

        Enemy enemyInstance = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        enemyInstance.Init(selectedEnemyBlueprint);
    }
}
