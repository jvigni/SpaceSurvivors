using UnityEngine;

public class TeleportArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
            Provider.SpawnManager.TeleportToRndSpawnPos(collision.transform);
    }
}
