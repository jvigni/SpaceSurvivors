using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float followingSpeed;

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    private void Update()
    {
        if(target != null)
            FollowTarget();
    }

    void FollowTarget()
    {
        Vector2 camPosition = transform.position;
        Vector2 targetPosition = target.transform.position;

        if (camPosition != targetPosition)
        {
            Vector3 moveDirection = targetPosition - camPosition;
            Vector3 moveForce = moveDirection * Time.deltaTime * followingSpeed;
            transform.position += moveForce;
        }
    }
}
