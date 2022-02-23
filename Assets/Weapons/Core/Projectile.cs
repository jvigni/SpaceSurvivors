using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float shakeIntensity = 0f;
    [SerializeField] DmgInfo dmgInfo;
    [SerializeField] ParticleSystem trayParticlesPrefab;
    [SerializeField] ParticleSystem explosionParticlesPrefab;
    [SerializeField] AudioClip explosionSFX;
    [SerializeField] AudioClip traySFX;
    [SerializeField] List<Effect> onHitEffects;

    Lifeform creator;
    ParticleSystem trayParticlesInstance;

    public Projectile BuildNew(Lifeform creator, Vector2 spawnPos, Quaternion rotation)
    {
        var instance = Instantiate(this, spawnPos, rotation);
        instance.creator = creator;
        return instance;
    }

    public void Push(Vector2 direction, float force)
    {
        GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);
    }

    void Start()
    {
        if (trayParticlesPrefab != null) 
            trayParticlesInstance = Instantiate(trayParticlesPrefab);

        /* [OK.. no quiero sonido ahora]
        // Tray SFX:
        if (traySFX)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = traySFX;
            audioSource.Play();
        }
        */

        StartCoroutine(SelfDestroy());
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSecondsRealtime(4);
        Destroy();
    }

    void Update()
    {
        if(trayParticlesInstance != null) 
            trayParticlesInstance.transform.position = transform.position;
    }

    protected void Destroy()
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
            Destroy(explosionParticlesInstance.gameObject);
        }

        // Shake: [OK - No quiero efectos ahora]
        //Camera.main.GetComponent<CameraEffects>().shake(shakeIntensity);

        /* [OK - No quiero sonido ahora
        // SFX:
        if (explosionSFX) AudioSource.PlayClipAtPoint(explosionSFX, transform.position);
        */

        Destroy(gameObject);
    }

    void OnTriggerEnter2D2(Collider2D col)
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((creator.tag.Equals("Enemy") && col.gameObject.tag.Equals("Player"))
            || (creator.tag.Equals("Player") && col.gameObject.tag.Equals("Enemy")))
        {
            Lifeform lifeForm = col.gameObject.GetComponent<Lifeform>();
            if (lifeForm)
            {
                lifeForm.ReceiveDamage(dmgInfo);
                //if(onHitEffects != null)
                //    onHitEffects.ForEach(effect => lifeForm.ApplyEffect(effect, creator));
            }
            Destroy();
        }

        if (col.gameObject.tag.Equals("Environment"))
            Destroy();
    }
}
