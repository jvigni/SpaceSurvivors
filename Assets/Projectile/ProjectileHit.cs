using UnityEngine;

public class ProjectileHit : MonoBehaviour
{
    [SerializeField] string targetTag;
    public float Damage;
    public float AOERadius;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Environment")) 
            Destroy();
        
        if (col.gameObject.tag.Equals(targetTag))
        {
            if (AOERadius > 0)
                HandleAOECollision(col.gameObject);
            else
                HandleSingleTargetCollision(col.gameObject);

            Destroy();
        }
    }

    void Destroy()
    {
        GetComponent<ProjectileParticles>()?.Destroy();
        Destroy(gameObject);
    }

    void HandleAOECollision(GameObject target)
    {
        var nearColliders = Physics2D.OverlapCircleAll(target.transform.position, AOERadius);
        foreach (Collider2D col in nearColliders)
            if(col.tag.Equals(targetTag))
                HandleSingleTargetCollision(col.gameObject);
    }

    void HandleSingleTargetCollision(GameObject target)
    {
        var lifeform = target.GetComponent<Lifeform>();
        if (lifeform) 
            lifeform.ReceiveDamage(new DmgInfo(Damage));
    }
}