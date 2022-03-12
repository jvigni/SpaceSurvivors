using System;
using UnityEngine;

[Serializable]
public class SpawnEnemyStageAction
{
    public EnemyID enemyID;
    public float spawnCooldownSeconds;

    public void Trigger()
    {
        //Como hago si no es MB? necesito corutinas aca..
        //Usar JOBs?
    }

    void SpawnEnemy()
    {
        var spawnPos = Provider.SpawnManager.GetRndSpawnAreaPos();
        var enemy = Instantiate(alien1, spawnPos, Quaternion.identity);
    }
}

public abstract class StageAction
{
    public float startMinute;
    public float finishMinute;

    public void Tri
}

[CreateAssetMenu(fileName = "Stage")]
public class Stage : ScriptableObject
{
    [SerializeField] SpawnAction[] spawnActions;
    

}

public class Stages
{
    public Stage Stage1()
    {
        return new Stage()
    }
}