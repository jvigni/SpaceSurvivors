using System.Collections;
using UnityEngine;

public class EnemiesSpawnManager : MonoBehaviour
{
    [SerializeField] GameObject alien1;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            var wfs = new WaitForSeconds(1);
            yield return wfs;

            var lvl = Provider.XpManager.Level;
            var amountToSpawn = lvl * Random.Range(1, 3);
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
        Instantiate(alien1, spawnPos, Quaternion.identity);
    }
}
