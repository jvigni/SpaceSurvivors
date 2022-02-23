using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown
{
    float countdown, originalSeconds;
    event Action OnFinish;

    public Cooldown(float seconds)
    {
        originalSeconds = seconds;
        countdown = seconds;
    }

    public float Status // Number between 1 (100% loaded / OnFinish is invoked) and 0 (0% loaded. Need to wait the full lenght)
    {
        get { return 1 - (countdown / originalSeconds); }
    }

    public bool IsReady
    {
        get { return countdown <= 0; }
    }

    public void Tick(float seconds)
    {
        countdown -= seconds;
        if (countdown <= 0) OnFinish?.Invoke();
    }
}

public class CooldownManager : MonoBehaviour
{
    float tickTimeSec = .01f;
    List<Cooldown> cooldowns = new List<Cooldown>();
    public static CooldownManager Instance;

    private void Awake()
    {
        Instance = this;    
    }

    private void Start()
    {
        StartCoroutine(ManageCooldowns());
    }

    public static Cooldown Start(float seconds)
    {
        var cooldown = new Cooldown(seconds);
        Instance.cooldowns.Add(cooldown);
        return cooldown;
    }

    IEnumerator ManageCooldowns()
    {
        var wfs = new WaitForSecondsRealtime(tickTimeSec);
        while (true)
        {
            yield return wfs;
            foreach (Cooldown cooldown in cooldowns)
                cooldown.Tick(tickTimeSec);
        }
    }    
}
