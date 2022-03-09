using UnityEngine;

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
