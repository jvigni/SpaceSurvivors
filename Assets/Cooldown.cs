using System;
using System.Threading;
using System.Threading.Tasks;

public class Cooldown
{
    public Action OnFinish;
    int tickTimeInMiliseconds = 100;
    float countdown, originalCooldown;
    Thread cooldownThread;
    
    public Cooldown(float seconds)
    {
        originalCooldown = seconds;
    }

    public bool IsReady()
    {
        return countdown <= 0;
    }

    public void Start(bool repeat = false)
    {
        if (cooldownThread != null)
            cooldownThread.Abort();

        countdown = originalCooldown;

        cooldownThread = new Thread(async () =>
        {
            while (countdown > 0)
            {
                await Task.Delay(tickTimeInMiliseconds);
                countdown -= tickTimeInMiliseconds / 1000f;
            }
            OnFinish?.Invoke();
        });
        cooldownThread.Start();
    }

    public float Status() //Number between 1(Full CD) and 0(Ready to use)
    {
        return countdown * 100 / originalCooldown;
    }
}