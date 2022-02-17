using System;
using System.Collections;
using UnityEngine;

public class Lifeform : MonoBehaviour
{
    public event Action OnDeath;
    [SerializeField] float actualHealth;

    public void Init(float maxHealth)
    {
        actualHealth = maxHealth;
    }

    public void ReceiveDamage(float damage)
    {
        actualHealth -= damage;
        StartCoroutine(HitColorChange());
        if (actualHealth <= 0)
            HandleDeath();
    }

    IEnumerator HitColorChange()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void HandleDeath()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}
