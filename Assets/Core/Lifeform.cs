using System;
using System.Collections;
using UnityEngine;

public class Lifeform : MonoBehaviour
{
    public event Action OnDeath;
    [SerializeField] float actualHealth;
    [SerializeField] HealthBar healthBar;

    public void Init(float maxHealth)
    {
        actualHealth = maxHealth;
        if (healthBar != null) healthBar.Init(maxHealth);
    }
    
    public void ReceiveDamage(DmgInfo dmgInfo)
    {
        actualHealth -= dmgInfo.Amount;
        StartCoroutine(HitColorChange());
        if (healthBar != null) 
            StartCoroutine(HandleHealthbar());
        if (actualHealth <= 0)
            HandleDeath();
    }

    IEnumerator HandleHealthbar()
    {
        healthBar.SetValue(actualHealth);
        healthBar.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        healthBar.gameObject.SetActive(false);
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
