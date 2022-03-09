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
