using System.Collections;
using UnityEngine;

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
