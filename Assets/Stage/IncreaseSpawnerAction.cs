public class IncreaseSpawnerAction : StageAction
{
    EnemyId enemyId;
    int increaseAmount;

    public IncreaseSpawnerAction(float minute, EnemyId enemyId, int increaseAmount)
        : base(minute)
    {
        this.enemyId = enemyId;
        this.increaseAmount = increaseAmount;
    }

    public override void Trigger()
    {
        Provider.SpawnManager.IncreaseSpawner(enemyId, increaseAmount);
    }
}
