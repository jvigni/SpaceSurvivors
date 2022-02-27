using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown
{
    public event Action<Cooldown> OnFinish;
    float countdown, originalSeconds;

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
        if (countdown <= 0) OnFinish?.Invoke(this);
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

    public Cooldown Start(float seconds)
    {
        var cooldown = new Cooldown(seconds);
        cooldown.OnFinish += cooldown => OnCooldownFinish(cooldown);
        cooldowns.Add(cooldown);
        return cooldown;
    }

    void OnCooldownFinish(Cooldown cooldown)
    {
        cooldowns.Remove(cooldown);
    }

    IEnumerator ManageCooldowns()
    {
        var wfs = new WaitForSeconds(tickTimeSec);
        while (true)
        {
            yield return wfs;
            foreach (Cooldown cooldown in cooldowns.ToArray())
                cooldown.Tick(tickTimeSec);
        }
    }    
}
