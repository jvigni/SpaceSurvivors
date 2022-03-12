using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LvAction : MonoBehaviour
{
    int triggerMinute;
    public LvAction(int triggerMinute, Action action)
    {
        this.triggerMinute = triggerMinute;
    }

    public abstract void Trigger();
}

public class Level1 : MonoBehaviour
{
    [SerializeField] GameObject batPrefab;

    private void Start()
    {
        StartCoroutine(ManageLevel());
    }

    IEnumerator ManageLevel()
    {
        while (true)
        {

        }
    }

    void BatSpawn()
    {
        int lvl = Provider.XpManager.Level;
        for (int i = 0; i < lvl; i++)
            SpawnEnemy(batPrefab);
    }

    GameObject SpawnEnemy(GameObject prefab)
    {
        var spawnPos = Provider.SpawnManager.GetRndSpawnAreaPos();
        return Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}

public abstract class Spawner : MonoBehaviour
{
    public abstract void Run();    
}

public class IncrementalBatsSpawner : Spawner
{
    [SerializeField] GameObject batPrefab;

    public override void Run()
    {
        StartCoroutine(Routine());
    }
    
    IEnumerator Routine()
    {
        var wfs = new WaitForSeconds(2);
        while (true)
        {
            yield return wfs;
            int lvl = Provider.XpManager.Level;
            for (int i = 0; i < lvl; i++)
                SpawnEnemy(batPrefab);
        }
    }

    GameObject SpawnEnemy(GameObject prefab)
    {
        var spawnPos = Provider.SpawnManager.GetRndSpawnAreaPos();
        return Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}

//---------------------------------------
