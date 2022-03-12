using UnityEngine;

public class SpawnEnemyAction : StageAction
{
    public EnemyID enemyId;
    public float spawnsPerSecond;
    Coroutine routine;

    public SpawnEnemyAction(int startMinute, int finishMinute, EnemyID enemyId, float spawnsPerSecond)
        : base(startMinute, finishMinute)
    {
        this.enemyId = enemyId;
        this.spawnsPerSecond = spawnsPerSecond;
    }

    public override void Run()
    {
        routine = Provider.SpawnManager.RunSpawnRoutine(enemyId, spawnsPerSecond, TotalSeconds);
    }

    public override void Stop()
    {
        Provider.SpawnManager.StopCoroutine(routine);
    }
}
