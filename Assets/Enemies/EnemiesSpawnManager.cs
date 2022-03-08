using System.Collections;
using UnityEngine;

public class EnemiesSpawnManager : MonoBehaviour
{
    [SerializeField] GameObject alien1;
    [SerializeField] RectTransform[] spawnAreas;

    private void Awake()
    {
        Provider.EnemiesSpawnManager = this;    
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    public void TeleportToRndSpawnArea(Transform transform)
    {
        var rndAreaIndex = Random.Range(0, spawnAreas.Length);
        transform.position = GetRndPosFromArea(spawnAreas[rndAreaIndex]);
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
        
        Instantiate(alien1, GetRndPosFromArea(spawnArea), Quaternion.identity);
    }

    Vector3 GetRndPosFromArea(RectTransform area)
    {
        var x = Random.Range(area.rect.xMin, area.rect.xMax);
        var y = Random.Range(area.rect.yMin, area.rect.yMax);
        return (Vector2)area.transform.position + new Vector2(x, y);
    }
}
