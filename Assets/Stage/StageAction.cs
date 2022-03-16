public abstract class StageAction
{
    public float StartMinute;

    public StageAction(float startMinute)
    {
        StartMinute = startMinute;
    }

    public abstract void Trigger();
}
