using UnityEngine;

public class EnemyLoot : MonoBehaviour
{
    [SerializeField] GameObject loot;
    [SerializeField] int dropPercentage;

    private void Start()
    {
        GetComponent<Lifeform>().OnDeath += _ => TryDropLoot();
    }

    void TryDropLoot()
    {
        if (Utils.Chance(dropPercentage))
            Instantiate(loot, transform.position, Quaternion.identity);
    }
}
