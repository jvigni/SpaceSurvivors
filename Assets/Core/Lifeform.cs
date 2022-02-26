using System.Collections;
using UnityEngine;

public class Lifeform : MonoBehaviour
{
    public event System.Action OnDeath;
    [SerializeField] float startingHealth = 100000f;
    public float ActualHealth { get; private set; }

    private void Awake()
    {
        ActualHealth = startingHealth;     
    }

    public void Init(float maxHealth)
    {
        startingHealth = maxHealth;
        ActualHealth = maxHealth;
    }
    
    public void ReceiveDamage(DmgInfo dmgInfo)
    {
        startingHealth -= dmgInfo.Amount;
        StartCoroutine(HitColorChange());
        if (startingHealth <= 0)
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
