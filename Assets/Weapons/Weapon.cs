using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] float cooldownSecs;
    protected Lifeform owner;
    bool autoShooting;

    public void Init(Lifeform owner)
    {
        this.owner = owner;
    }

    public void StartAutoshooting()
    {
        autoShooting = true;
        StartCooldown();
    }

    public void StopAutoshooting()
    {
        autoShooting = false;
    }

    void StartCooldown()
    {
        var cooldown = Provider.CooldownManager.Start(cooldownSecs);
        cooldown.OnFinish += _ => OnCooldownFinished();
    }

    void OnCooldownFinished()
    {
        if (!autoShooting)
            return;

        Trigger();
        StartCooldown();
    }

    public abstract void Trigger();
}
