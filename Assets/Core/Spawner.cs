using System.Collections.Generic;
using UnityEngine;
 
public class Spawner : MonoBehaviour
{
    EnemyID enemyId;
    List<GameObject> entities = new List<GameObject>();
    int maxInstances;
    public int MaxInstances
    {
        get { return maxInstances; }
        set 
        {
            int increment = value - maxInstances;
            if(increment > 0)
                for (int i = 0; i < increment; i++)
                    SpawnEnemy();

            maxInstances = value;
        }
    }

    public static Spawner New(EnemyID enemyId, int maxInstances)
    {
        var spawnerGO = new GameObject($"Spawner: {enemyId}");
        Spawner spawnerComponent = spawnerGO.AddComponent<Spawner>();
        spawnerComponent.enemyId = enemyId;
        spawnerComponent.MaxInstances = maxInstances;
        return spawnerComponent;
    }

    void SpawnEnemy()
    {
        var enemy = Provider.SpawnManager.SpawnEnemy(enemyId);
        enemy.GetComponent<Lifeform>().OnDeath += OnEnemyDeath;
        entities.Add(enemy);
    }

    void OnEnemyDeath(Lifeform lifeform)
    {
        entities.Remove(lifeform.gameObject);
        SpawnEnemy();
    }

    private void OnDestroy()
    {
        foreach (GameObject entity in entities)
           entity.GetComponent<Lifeform>().OnDeath -= OnEnemyDeath;
    }
}
