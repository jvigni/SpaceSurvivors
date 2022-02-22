using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Nova : MonoBehaviour
{
    [SerializeField] float radiusIncrementSpeed;
    [SerializeField] float maxRadius;
    
    private CircleCollider2D collider;
    private ShapeModule shapeModule;

    private void Start()
    {
        collider = GetComponent<CircleCollider2D>();
        shapeModule = GetComponent<ParticleSystem>().shape;
        shapeModule.radius = 0;
    }

    void Update()
    {
        if (collider.radius >= maxRadius)
            Destroy(gameObject);

        shapeModule.radius += radiusIncrementSpeed;
        collider.radius += radiusIncrementSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
