﻿using System.Collections;
using UnityEngine;

public class SelfGuidedProjectile : MonoBehaviour 
{
    [SerializeField] float movementSpeed;
    [SerializeField] float turningSpeed;
    [SerializeField] float findRange;
    [SerializeField] LayerMask targetLayer;
    GameObject target;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(UpdateTargetRoutine());
    }

    IEnumerator UpdateTargetRoutine()
    {
        var wfs = new WaitForSeconds(.1f);
        while (true)
        {
            target = Utils.FindNearest(transform.position, findRange, targetLayer);
            yield return wfs;
        }
    }

    void Update () {

        if (target != null)
            RotateTowardsTarget();

        //Movement
        //float finalSpeed = movementSpeed + Random.Range(-movementSpeedError, movementSpeedError);
        Vector3 movement = transform.up * movementSpeed * Time.fixedDeltaTime;
        rb.MovePosition(transform.position + movement);
    }

    void RotateTowardsTarget()
    {
        float turning = Vector3.Dot(transform.right, target.transform.position - transform.position);
        if (turning > 0) transform.Rotate(new Vector3(0, 0, -turningSpeed));
        if (turning < 0) transform.Rotate(new Vector3(0, 0, turningSpeed));
    }
}
