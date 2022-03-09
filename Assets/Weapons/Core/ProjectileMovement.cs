using System.Collections;
using UnityEngine;

public class ProjectileParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem trayParticlesPrefab;
    [SerializeField] ParticleSystem explosionParticlesPrefab;
    ParticleSystem trayParticlesInstance;

    void Start()
    {
        if (trayParticlesPrefab != null)
            trayParticlesInstance = Instantiate(trayParticlesPrefab);
    }

    void Update()
    {
        if (trayParticlesInstance != null)
            trayParticlesInstance.transform.position = transform.position;
    }

    public void Destroy()
    {
        if (trayParticlesInstance != null)
        {
            trayParticlesInstance.Stop();
            trayParticlesInstance.transform.parent = null; // This splits the particle off so it doesn't get deleted with the parent
            Destroy(trayParticlesInstance.gameObject);
        }

        if (explosionParticlesPrefab != null)
        {
            ParticleSystem explosionParticlesInstance = Instantiate(explosionParticlesPrefab);
            explosionParticlesInstance.transform.position = transform.position;
            explosionParticlesInstance.transform.parent = null;
            //Destroy(explosionParticlesInstance.gameObject);
        }
    }
}

public class ProjectileSelfDestruction : MonoBehaviour
{
    [SerializeField] float secondsToSelfDestruct;

    void Start()
    {
        StartCoroutine(SelfDestroy());
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(secondsToSelfDestruct);
        Destroy();
    }

    protected void Destroy()
    {
        GetComponent<ProjectileParticles>()?.Destroy();
        Destroy(gameObject);
    }
}

public class ProjectileMovement : MonoBehaviour
{
    public void Push(Vector2 direction, float force)
    {
        GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);
    }

    public void RotateTowards(Transform target)
    {
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GetComponent<Rigidbody2D>().rotation = angle - 90;
    }    
}

public class ProjectileHit : MonoBehaviour
{
    [SerializeField] LayerMask targetLayer;
    public float Damage { get; private set; }
    public float AOERadius { get; private set; }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Environment")) 
            Destroy();
        
        if (col.gameObject.layer.Equals(targetLayer))
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
        var nearColliders = Physics2D.OverlapCircleAll(target.transform.position, AOERadius, targetLayer);
        foreach (Collider2D col in nearColliders)
            HandleSingleTargetCollision(col.gameObject);
    }

    void HandleSingleTargetCollision(GameObject target)
    {
        var lifeform = target.GetComponent<Lifeform>();
        if (lifeform) lifeform.ReceiveDamage(new DmgInfo(Damage));
    }
}