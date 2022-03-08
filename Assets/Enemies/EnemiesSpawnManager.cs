using System.Collections;
using UnityEngine;

public class EnemiesSpawnManager : MonoBehaviour
{
    [SerializeField] GameObject alien1;
    [SerializeField] RectTransform[] spawnAreas;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            var wfs = new WaitForSeconds(Random.Range(1, 1));
            yield return wfs;

            var lvl = Provider.XpManager.Level;
            var amountToSpawn = lvl;
            for (int i = 0; i < amountToSpawn; i++)
                for(int j = 0; j < spawnAreas.Length; j++)
                    SpawnEnemy(spawnAreas[j]);
        }
    }

    void SpawnEnemy(RectTransform spawnArea)
    {
        /*
        float minRadius = 20f;
        float radius = minRadius + Random.Range(0f, 10f);
        float angle = Random.Range(0, 359);
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        var spawnPos = Provider.Spaceship.transform.position + new Vector3(x, y);
        */
        var x = Random.Range(spawnArea.rect.xMin, spawnArea.rect.xMax);
        var y = Random.Range(spawnArea.rect.yMin, spawnArea.rect.yMax);
        Vector2 spawnPos = (Vector2)spawnArea.transform.position + new Vector2(x, y);
        Instantiate(alien1, spawnPos, Quaternion.identity);
    }
}
