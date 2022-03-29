using System.Collections;
using UnityEngine;

//TODO: Ahora hace 1 hit unico por colision. fixear esto (Tiene que continuar atacando si sigue en la misma colision)
public class BasicEnemyAttack : MonoBehaviour
{
    [SerializeField] int damage;
    bool canAttack = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!canAttack || !collision.gameObject.tag.Equals("Player")) return;
        Attack(collision.gameObject);
    }

    void Attack(GameObject target)
    {
        target.GetComponent<Lifeform>().ReceiveDamage(damage);
        canAttack = false;
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(.5f);
        canAttack = true;
    }
}
