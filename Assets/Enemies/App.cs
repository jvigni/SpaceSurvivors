using UnityEngine;
using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;

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
    }

    /*
    void SpawnEnemy()
    {
        EntityArchetype archetype = entityManager.CreateArchetype(
            typeof(EnemyData),
            typeof(RenderMesh),
            typeof(LocalToWorld));
        Entity entity = entityManager.CreateEntity(archetype);
        entityManager.SetComponentData(entity, new EnemyData { hitpoints = 69 });
    }*/
}
