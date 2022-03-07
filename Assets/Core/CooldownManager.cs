using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observ
{
    public bool Done { get; private set; }


}

public class Cooldown
{
    public float Seconds;
    public bool Repeat;
    public IEnumerator OnFinishAction;
    float countdown;
    
    public Cooldown(float seconds, IEnumerator onFinishAction, bool repeat = false)
    {
        Seconds = seconds;
        countdown = seconds;
        Repeat = repeat;
        OnFinishAction = onFinishAction;
    }

    public void Start()
    {
        Provider.CooldownManager.Start(this);
    }

    public void Stop()
    {
        Provider.CooldownManager.Stop(this);
    }

    public void Reset()
    {
        countdown = Seconds;
    }

    public float Status // Number between 1 (100% loaded / OnFinish is invoked) and 0 (0% loaded. Need to wait the full lenght)
    {
        get { return 1 - (countdown / Seconds); }
    }

    public bool IsReady
    {
        get { return countdown <= 0; }
    }

    public void Tick(float seconds)
    {
        countdown -= seconds;
    }
}

public class CooldownManager : MonoBehaviour
{
    float tickTimeSec = .01f;
    List<Cooldown> cooldowns = new List<Cooldown>();

    private void Awake()
    {
        Provider.CooldownManager = this;
    }

    private void Start()
    {
        StartCoroutine(ManageCooldowns());
    }

    public void Stop(Cooldown cooldown)
    {
        cooldowns.Remove(cooldown);
    }

    public void Start(Cooldown cooldown)
    {
        cooldowns.Add(cooldown);
    }

    void OnCooldownFinish(Cooldown cooldown)
    {
        Debug.Log("Cooldown finish");
        var job = Job.make(cooldown.OnFinishAction);
        job.jobComplete += _ => AfterActionCompletes(cooldown);
    }

    void AfterActionCompletes(Cooldown cooldown)
    {
        if (cooldown.Repeat)
            cooldown.Reset();
        else
            cooldowns.Remove(cooldown);
    }

    IEnumerator ManageCooldowns()
    {
        var wfs = new WaitForSeconds(tickTimeSec);
        while (true)
        {
            yield return wfs;
            foreach (Cooldown cooldown in cooldowns.ToArray())
            {
                if (cooldown.IsReady)
                    OnCooldownFinish(cooldown);
                else
                    cooldown.Tick(tickTimeSec);
            }
        }
    }
}
