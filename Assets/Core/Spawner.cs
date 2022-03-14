using System.Collections.Generic;
using UnityEngine;
 
public class Spawner : MonoBehaviour
{
    public EnemyID enemyId;
    public int maxInstances;
    List<GameObject> entities = new List<GameObject>();

    private void Start()
    {
        Run(enemyId, maxInstances);    
    }

    public void Run(EnemyID enemyId, int maxInstances)
    {
        this.maxInstances = maxInstances;
        this.enemyId = enemyId;
        for (int i = 0; i < maxInstances; i++)
            SpawnEnemy();
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
