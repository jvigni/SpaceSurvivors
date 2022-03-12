using System.Collections.Generic;

public class SpawnEnemyAction : StageAction
{
    public EnemyID enemyId;
    public float spawnsPerSecond;

    public SpawnEnemyAction(int startMinute, int finishMinute, EnemyID enemyId, float spawnsPerSecond)
        : base(startMinute, finishMinute)
    {
        this.enemyId = enemyId;
        this.spawnsPerSecond = spawnsPerSecond;
    }

    public override void Run()
    {
        Provider.SpawnManager.RunSpawnRoutine(enemyId, spawnsPerSecond, TotalSeconds);
    }
}

public abstract class StageAction
{
    public int startMinute;
    public int finishMinute;

    public StageAction(int startMinute, int finishMinute)
    {
        this.startMinute = startMinute;
        this.finishMinute = finishMinute;
    }

    protected float TotalSeconds => (finishMinute - startMinute) * 60;
    public abstract void Run();
}

public class Stage
{
    public string Title;
    List<StageAction> actions = new List<StageAction>();
    
    public Stage(string title, params StageAction[] actions)
    {
        Title = title;
        foreach (StageAction action in actions)
            this.actions.Add(action);
    }
}

public class Stages
{
    public static Stage Stage1()
    {
        return new Stage("Stage I",
            new SpawnEnemyAction(0, 1, EnemyID.Alien1, .5f),
            new SpawnEnemyAction(1, 2, EnemyID.Asteroid, .5f));
    }
}