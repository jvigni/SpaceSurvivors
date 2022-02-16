using System;
using UnityEngine;

public class Lifeform : MonoBehaviour
{
    public Action OnDeath;
    float actualHealth;

    public void Init(float maxHealth)
    {
        actualHealth = maxHealth;
    }

    public void ReceiveDamage(float damage)
    {
        actualHealth -= damage;
        if (actualHealth <= 0)
            HandleDeath();
    }

    void HandleDeath()
    {
        OnDeath.Invoke();
        Destroy(gameObject);
    }
}
