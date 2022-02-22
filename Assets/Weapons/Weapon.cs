using System;
using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    float cooldownSecs;
    float cooldownCountdown;
    Coroutine autoshootingRoutine;
    protected Lifeform owner;

    public Weapon(float cooldownSecs)
    {
        this.cooldownSecs = cooldownSecs;
    }

    public void StartAutoshooting()
    {
        autoshootingRoutine = StartCoroutine(ShootRoutine());
    }

    public void Init(Lifeform owner)
    {
        this.owner = owner;
    }

    public void StopAutoshooting()
    {
        StopCoroutine(autoshootingRoutine);
    }

    IEnumerator ShootRoutine()
    {
        var wfs = new WaitForSecondsRealtime(1);
        while (true)
        {
            while (cooldownCountdown > 0)
            {
                yield return wfs;
                cooldownCountdown -= 1;
            }
            Trigger();
            cooldownCountdown = cooldownSecs;
        }
    }

    public abstract void Trigger();
}
