public abstract class StageAction
{
    public float StartMinute;
    public float EndMinute;

    public StageAction(float startMinute, float endMinute)
    {
        StartMinute = startMinute;
        EndMinute = endMinute;
    }

    protected float TotalSeconds => (EndMinute - StartMinute) * 60f;
    public abstract void Run();
    public abstract void Stop();
}
