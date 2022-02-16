using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float followingSpeed;

    private void Update()
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
