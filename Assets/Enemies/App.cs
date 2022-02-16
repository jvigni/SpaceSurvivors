using Unity.Entities;
using UnityEngine;

public class Provider
{
    public static Spaceship Spaceship;
}

public class App : MonoBehaviour
{
    EntityManager entityManager;

    private void Start()
    {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        for(int i = 0; i < 10; i++)
            SpawnEnemy();
    }

    void SpawnEnemy()
    {
        EntityArchetype archetype = entityManager.CreateArchetype(typeof(EnemyData));
        Entity entity = entityManager.CreateEntity(archetype);
        entityManager.SetComponentData(entity, new EnemyData { hitpoints = 69 });
    }
}
