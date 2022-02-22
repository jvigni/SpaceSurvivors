using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyBlueprint blueprint;
    Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;
    bool canAttack = true;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Init(EnemyBlueprint blueprint)
    {
        this.blueprint = blueprint;
        GetComponent<Lifeform>().Init(blueprint.maxHealth);
        GetComponent<AnimatorLite>().Play(blueprint.idleAnim, true);
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        transform.position = Vector2.MoveTowards(transform.position, Provider.Spaceship.transform.position, blueprint.speed * Time.deltaTime);
    }

    void HandleRotation()
    {
        if (Provider.Spaceship.transform.position.x < transform.position.x)
            spriteRenderer.flipX = true;
        else if (spriteRenderer.flipX)
            spriteRenderer.flipX = false;
    }

    void FaceSpaceship()
    {
        Vector2 direction = Provider.Spaceship.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rigidBody.rotation = angle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && canAttack)
        {
            collision.gameObject.GetComponent<Lifeform>().ReceiveDamage(blueprint.dmgInfo);
            canAttack = false;
            StartCoroutine(ResetAttackCooldown());
        }
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSecondsRealtime(.5f);
        canAttack = true;
    }
}