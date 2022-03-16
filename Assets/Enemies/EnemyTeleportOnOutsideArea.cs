using UnityEngine;

public class EnemyTeleportOnOutsideArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("OutsideArea"))
            Provider.SpawnManager.TeleportToRndSpawnPos(transform);
    }
}
