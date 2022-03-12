using System.Collections.Generic;
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

public abstract class StageAction
{
    public int StartMinute;
    public int FinishMinute;

    public StageAction(int startMinute, int finishMinute)
    {
        StartMinute = startMinute;
        FinishMinute = finishMinute;
    }

    protected float TotalSeconds => (FinishMinute - StartMinute) * 60;
    public abstract void Run();
    public abstract void Stop();
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

    public void Run()
    {
        var timer = Provider.Timer;
        timer.Minute += minute => OnNewMinute(minute);
        timer.Run();
    }

    void OnNewMinute(int minute)
    {
        foreach(StageAction action in actions)
        {
            if (action.StartMinute == minute)
                action.Run();

            if (action.FinishMinute == minute)
                action.Stop();
        }
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