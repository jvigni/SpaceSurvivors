using UnityEngine;

[CreateAssetMenu(fileName = "EnemyBlueprint")]
public class EnemyBlueprint : ScriptableObject
{
    public float maxHealth;
    public DmgInfo dmgInfo;
    public float speed;
    public int experience;
    public AnimData idleAnim;
    public AnimData deathAnim;
}
