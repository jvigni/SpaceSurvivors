using UnityEngine;

public class SpawnEnemyAction : StageAction
{
    public EnemyId enemyId;
    public float spawnsPerSecond;
    Coroutine routine;

    public SpawnEnemyAction(float startMinute, float endMinute, EnemyId enemyId, float spawnsPerSecond)
        : base(startMinute, endMinute)
    {
        this.enemyId = enemyId;
        this.spawnsPerSecond = spawnsPerSecond;
    }

    public override void Run()
    {
        //routine = Provider.SpawnManager.RunSpawnRoutine(enemyId, spawnsPerSecond, TotalSeconds);
        //TODO
    }

    public override void Stop()
    {
        Provider.SpawnManager.StopCoroutine(routine);
    }
}
