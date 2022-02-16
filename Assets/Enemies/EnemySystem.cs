using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;

public class EnemySystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref EnemyData enemyData) =>
        {
            enemyData.hitpoints += 1;
        }).Schedule();
    }
}
