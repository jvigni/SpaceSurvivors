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
