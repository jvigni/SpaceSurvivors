using System;
using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] float cooldownSecs;
    float cooldownCountdown;
    Coroutine autoshootingRoutine;
    protected Lifeform owner;

    public void ResetCooldown()
    {
        cooldownCountdown = cooldownSecs;
    }

    public void ReduceCooldown(float seconds)
    {
        cooldownCountdown -= seconds;
        if (cooldownCountdown <= 0)
        {
            Trigger();
            cooldownCountdown = cooldownSecs;
        }
    }

    public void Init(Lifeform owner)
    {
        this.owner = owner;
    }

    public abstract void Trigger();
}
