using UnityEngine;

[CreateAssetMenu(fileName = "EnemyBlueprint")]
public class EnemyBlueprint : ScriptableObject
{
    public float maxHealth;
    public float speed;
    public AnimData idleAnim;
    public AnimData deathAnim;
}
