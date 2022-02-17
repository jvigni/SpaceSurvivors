using System;
using System.Threading;
using System.Threading.Tasks;

// DEPRECADO!
public class Cooldown
{
    public Action OnFinish;
    int tickTimeInMiliseconds = 100;
    float countdown, originalCooldown;
    Thread cooldownThread;

    public float Status // Number between 1 (100% loaded / OnFinish invoked) and 0 (0% loaded. Need to wait the full lenght)
    {
        get { return 1 - (countdown / originalCooldown); }
    }

    public bool IsReady
    {
        get { return countdown <= 0; }
    }

    public Cooldown(float seconds)
    {
        originalCooldown = seconds;
    }

    public void Start(bool repeat = false)
    {
        countdown = originalCooldown;
        cooldownThread = new Thread(async () =>
        {
            do
            {
                while (countdown > 0)
                {
                    await Task.Delay(tickTimeInMiliseconds);
                    countdown -= tickTimeInMiliseconds / 1000f;
                }
                OnFinish?.Invoke();
            } while (repeat);
        });
        cooldownThread.Start();
    }

    public void Stop()
    {
        cooldownThread.Abort();
    }
}