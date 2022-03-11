using System.Collections;
using UnityEngine;

public class EnemiesSpawnManager : MonoBehaviour
{
    [SerializeField] GameObject alien1;

    private void Awake()
    {
        Provider.EnemiesSpawnManager = this;    
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        var wfs = new WaitForSeconds(3f);//Random.Range(1, 1));
        while (true)
        {
            var lvl = Provider.XpManager.Level;
            var amountToSpawn = lvl; //Random.Range(2, 2 + 2*lvl);
            for (int i = 0; i < amountToSpawn; i++)
                SpawnEnemy();
            
            yield return wfs;
        }
    }

    void SpawnEnemy()
    {
        /*
        float minRadius = 20f;
        float radius = minRadius + Random.Range(0f, 10f);
        float angle = Random.Range(0, 359);
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        var spawnPos = Provider.Spaceship.transform.position + new Vector3(x, y);
        */
        var spawnPos = Provider.SpawnManager.GetRndSpawnAreaPos();
        var enemy = Instantiate(alien1, spawnPos, Quaternion.identity);
    }
}
