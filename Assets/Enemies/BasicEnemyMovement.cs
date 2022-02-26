using UnityEngine;

public class BasicEnemyMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        transform.position = 
            Vector2.MoveTowards(transform.position, Provider.Spaceship.transform.position, movementSpeed * Time.deltaTime);
    }

    void HandleRotation()
    {
        if (Provider.Spaceship.transform.position.x < transform.position.x)
            spriteRenderer.flipX = true;
        else if (spriteRenderer.flipX)
            spriteRenderer.flipX = false;
    }
}
