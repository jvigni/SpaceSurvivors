using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool Pierce; //Does not destroy on hit
    [SerializeField] float AOERadius = 0f;
    [SerializeField] float shakeIntensity = 0f;
    [SerializeField] DmgInfo dmgInfo;
    [SerializeField] ParticleSystem trayParticlesPrefab;
    [SerializeField] ParticleSystem explosionParticlesPrefab;
    [SerializeField] AudioClip explosionSFX;
    [SerializeField] AudioClip traySFX;
    [SerializeField] List<Effect> onHitEffects;

    GameObject creator;
    ParticleSystem trayParticlesInstance;

    public Projectile BuildNew(GameObject creator, Vector2 spawnPos, Quaternion rotation)
    {
        var instance = Instantiate(this, spawnPos, rotation);
        instance.creator = creator;
        return instance;
    }

    public void Push(Vector2 direction, float force)
    {
        GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);
    }

    public void RotateTowards(Transform target)
    {
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GetComponent<Rigidbody2D>().rotation = angle -90;
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
        yield return new WaitForSeconds(4);
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
            //Destroy(explosionParticlesInstance.gameObject);
        }

        // Shake: [OK - No quiero efectos ahora]
        //Camera.main.GetComponent<CameraEffects>().shake(shakeIntensity);

        /* [OK - No quiero sonido ahora
        // SFX:
        if (explosionSFX) AudioSource.PlayClipAtPoint(explosionSFX, transform.position);
        */

        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.tag.Equals("Enemy")) return;
        if (col.gameObject.tag.Equals("Environment")) Destroy();

        if (AOERadius > 0)
            HandleAOECollision(col.gameObject);
        else
            HandleSingleTargetCollision(col.gameObject);

        if(!Pierce) Destroy();
    }

    void HandleAOECollision(GameObject target)
    {
        var nearColliders = Physics2D.OverlapCircleAll(target.transform.position, AOERadius);
        foreach (Collider2D candidate in nearColliders)
            if(candidate.tag.Equals("Enemy"))
                HandleSingleTargetCollision(candidate.gameObject);
    }

    void HandleSingleTargetCollision(GameObject target)
    {
        var lifeform = target.GetComponent<Lifeform>();
        if(lifeform) lifeform.ReceiveDamage(dmgInfo);
    }
}
