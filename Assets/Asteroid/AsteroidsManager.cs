using System.Collections;
using UnityEngine;

public class AsteroidsManager : MonoBehaviour
{
    [SerializeField] GameObject asteroidPrefab;
    int spawnAmount = 1;

    private void Start()
    {
        StartCoroutine(HandleAsteroids());
    }

    IEnumerator HandleAsteroids()
    {
        var wfs = new WaitForSeconds(3);
        while (true)
        {
            yield return wfs;
            var seconds = Provider.Timer.ElapsedSeconds;
            if (seconds >= 60)
                spawnAmount = 2;
            if (seconds >= 120)
                spawnAmount = 3;
            for (int i = 0; i < spawnAmount; i++)
                SpawnAsteroid();
        }
    }

    void SpawnAsteroid()
    {
        var spawnPos = Provider.SpawnManager.GetRndSpawnAreaPos();
        Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);
    }
}
