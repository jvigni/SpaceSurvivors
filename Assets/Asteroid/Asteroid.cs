using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] float spaceshipTargetRadius;
    [SerializeField] float minPushForce;
    [SerializeField] float maxPushForce;

    private void Start()
    {
        Vector2 spaceshipPos = Provider.Spaceship.transform.position;
        Vector2 rndCirclePos = spaceshipTargetRadius * Random.insideUnitCircle;
        Vector2 finalPos = spaceshipPos + rndCirclePos;
        Vector2 dir = (finalPos - (Vector2)transform.position).normalized;
        var movement = GetComponent<ProjectileMovement>();
        var force = Random.Range(minPushForce, maxPushForce);
        movement.Push(dir, force);
        movement.RotateTowards(Provider.Spaceship.transform);
    }
}
