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
