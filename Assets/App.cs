using UnityEngine;

public class Provider
{
    public static Spaceship Spaceship;
}

public class App : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] EnemyBlueprint selectedEnemyBlueprint;

    private void Start()
    {
        for(int i = 0; i < 1000; i++)
            SpawnEnemy();
    }

    void SpawnEnemy()
    {
        float minRadius = 20f;
        float radius = minRadius + Random.Range(0f, 10f);
        float angle = Random.Range(0, 359);
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        Enemy enemyInstance = Instantiate(enemyPrefab, new Vector2(x,y), Quaternion.identity);
        enemyInstance.Init(selectedEnemyBlueprint);
    }
}
