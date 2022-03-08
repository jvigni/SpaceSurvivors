using System.Collections;
using UnityEngine;

public class EnemyTeleportNearPlayer : MonoBehaviour
{
    [SerializeField] float maxDistance;
    [SerializeField] float intervalCheckSeconds;

    private void Start()
    {
        StartCoroutine(Routine());
    }

    void TeleportNearPlayer()
    {
        Provider.EnemiesSpawnManager.TeleportToRndSpawnArea(transform);
    }

    IEnumerator Routine()
    {
        var wfs = new WaitForSeconds(intervalCheckSeconds);
        while (true)
        {
            yield return wfs;
            var distanceToPlayer = Vector2.Distance(transform.position, Provider.Spaceship.transform.position);
            if (distanceToPlayer > maxDistance)
                TeleportNearPlayer();
        }
    }
}
