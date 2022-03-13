public abstract class StageAction
{
    public float StartMinute;
    public float FinishMinute;

    public StageAction(float startMinute, float finishMinute)
    {
        StartMinute = startMinute;
        FinishMinute = finishMinute;
    }

    protected float TotalSeconds => (FinishMinute - StartMinute) * 60f;
    public abstract void Run();
    public abstract void Stop();
}
