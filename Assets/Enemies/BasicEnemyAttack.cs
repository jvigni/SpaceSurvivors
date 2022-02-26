using System.Collections;
using UnityEngine;

public class BasicEnemyAttack : MonoBehaviour
{
    [SerializeField] DmgInfo damage;
    bool canAttack;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!canAttack || !collision.gameObject.tag.Equals("Player")) return;
            
        canAttack = false;
        collision.gameObject.GetComponent<Lifeform>().ReceiveDamage(damage);
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSecondsRealtime(.5f);
        canAttack = true;
    }
}
