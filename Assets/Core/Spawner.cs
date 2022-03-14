using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool enabled;
    public EnemyID enemyId;
    public int maxInstances;

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
        enemy.GetComponent<Lifeform>().OnDeath += () => OnEnemyDeath();
    }

    void OnEnemyDeath()
    {
        if(isActiveAndEnabled)
            SpawnEnemy();
    }
}
