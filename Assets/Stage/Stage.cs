using System.Collections.Generic;

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
        timer.Second += second => CheckActions(second);
        timer.Run();
    }

    void CheckActions(int second)
    {
        foreach(StageAction action in actions)
        {
            if (action.StartMinute == second / 60f)
                action.Run();

            if (action.FinishMinute == second / 60f)
                action.Stop();
        }
    }
}
