using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum EnemyID
{
    Alien1,
    Asteroid,
}

[System.Serializable]
public class EnemyData
{
    public EnemyID EnemyId;
    public GameObject Prefab;
}

public class SpawnData
{
    public GameObject prefab;
    public int maxInstances;
    public List<GameObject> instances;

    public bool Fullfilled => instances.Count == maxInstances;
}

public class SpawnManager : MonoBehaviour
{
    [SerializeField] RectTransform[] spawnAreas;
    [SerializeField] List<EnemyData> enemyData;

    private void Awake()
    {
        Provider.SpawnManager = this;
    }

    public Coroutine RunSpawnRoutine(EnemyID enemyID, float spawnsPerSecond, float totalSeconds)
    {
        return StartCoroutine(SpawnRoutine(enemyID, spawnsPerSecond, totalSeconds));
    }

    public void TeleportToRndSpawnPos(Transform transform)
    {
        var spawnPos = GetRndSpawnPos();
        transform.position = spawnPos;
    }

    IEnumerator SpawnRoutine(EnemyID enemyId, float spawnsPerSecond, float totalSeconds)
    {
        float elapsedSeconds = 0;
        var wfs = new WaitForSeconds(spawnsPerSecond);
        var prefab = GetEnemyPrefab(enemyId);
        while (elapsedSeconds < totalSeconds)
        {
            yield return wfs;
            SpawnEnemy(prefab);
            elapsedSeconds += spawnsPerSecond;
        }
    }

    public GameObject SpawnEnemy(EnemyID enemyId)
    {
        var prefab = GetEnemyPrefab(enemyId);
        return SpawnEnemy(prefab);
    }

    GameObject SpawnEnemy(GameObject prefab)
    {
        var spawnPos = GetRndSpawnPos();
        return Instantiate(prefab, spawnPos, Quaternion.identity);
    }

    GameObject GetEnemyPrefab(EnemyID id)
    {
        return enemyData
                .Where(enemyData => enemyData.EnemyId.Equals(id))
                .FirstOrDefault()
                .Prefab;
    }

    Vector3 GetRndSpawnPos()
    {
        var rndArea = spawnAreas[Random.Range(0, spawnAreas.Length)];
        var x = Random.Range(rndArea.rect.xMin, rndArea.rect.xMax);
        var y = Random.Range(rndArea.rect.yMin, rndArea.rect.yMax);
        return (Vector2)rndArea.transform.position + new Vector2(x, y);
    }
}
