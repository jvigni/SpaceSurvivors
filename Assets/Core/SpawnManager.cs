using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum EnemyId
{
    Alien1,
    Asteroid,
}

[System.Serializable]
public class EnemyData
{
    public EnemyId EnemyId;
    public GameObject Prefab;
}

public class SpawnManager : MonoBehaviour
{
    [SerializeField] RectTransform[] spawnAreas;
    [SerializeField] List<EnemyData> enemyData;
    List<Spawner> spawners = new List<Spawner>();

    private void Awake()
    {
        Provider.SpawnManager = this;
    }

    public void IncreaseSpawner(EnemyId enemyId, int increaseAmount)
    {
        var spawner = GetSpawner(enemyId);
        if (spawner == null)
            spawner = SpawnSpawner(enemyId);

        spawner.MaxInstances += increaseAmount;
    }

    Spawner SpawnSpawner(EnemyId enemyId)
    {
        var spawner = Spawner.New(enemyId);
        spawners.Add(spawner);
        return spawner;
    }

    Spawner GetSpawner(EnemyId enemyId)
    {
        foreach (Spawner spawner in spawners)
            if (spawner.EnemyId == enemyId)
                return spawner;
        return null;
    }

    public void TeleportToRndSpawnPos(Transform transform)
    {
        var spawnPos = GetRndSpawnPos();
        transform.position = spawnPos;
    }

    public GameObject SpawnEnemy(EnemyId enemyId)
    {
        var prefab = GetEnemyPrefab(enemyId);
        return SpawnEnemy(prefab);
    }

    GameObject SpawnEnemy(GameObject prefab)
    {
        var spawnPos = GetRndSpawnPos();
        return Instantiate(prefab, spawnPos, Quaternion.identity);
    }

    GameObject GetEnemyPrefab(EnemyId id)
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
