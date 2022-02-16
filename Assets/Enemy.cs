using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyBlueprint blueprint;
    float actualHealth;
    Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Init(EnemyBlueprint blueprint)
    {
        this.blueprint = blueprint;
        actualHealth = blueprint.maxHealth;
        GetComponent<AnimatorLite>().Play(blueprint.idleAnim, true);
    }

    private void Update()
    {
        HandleMovement();
        FaceSpaceship();
        //HandleRotation(); //Al ser naves topDown, no hace falta
    }

    void HandleMovement()
    {
        transform.position = Vector2.MoveTowards(transform.position, Provider.Spaceship.transform.position, blueprint.speed * Time.deltaTime);
    }

    void FaceSpaceship()
    {
        Vector2 direction = Provider.Spaceship.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rigidBody.rotation = angle;
    }

    void HandleRotation()
    {
        if (Provider.Spaceship.transform.position.x < transform.position.x)
            spriteRenderer.flipX = true;
        else if (spriteRenderer.flipX)
            spriteRenderer.flipX = false;
    }
}
