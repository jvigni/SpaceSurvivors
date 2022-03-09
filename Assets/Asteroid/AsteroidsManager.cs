using System.Collections;
using UnityEngine;

public class AsteroidsManager : MonoBehaviour
{
    [SerializeField] GameObject asteroidPrefab;

    private void Start()
    {
        StartCoroutine(HandleAsteroids());
    }

    IEnumerator HandleAsteroids()
    {
        var wfs = new WaitForSeconds(1);
        while (true)
        {
            yield return wfs;
            SpawnAsteroid();
        }
    }

    void SpawnAsteroid()
    {
        var spawnPos = Provider.SpawnManager.GetRndSpawnAreaPos();
        var asteroid = Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);
    }
}
