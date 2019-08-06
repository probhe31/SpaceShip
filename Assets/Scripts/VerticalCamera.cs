using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalCamera : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    bool hasTarget = false;

    private void Awake()
    {
        this.hasTarget = true;
    }

    public void RemoveTarget()
    {
        this.target = null;
        this.hasTarget = false;
    }

    public void SetTarget(Transform _target)
    {
        this.target = _target;
        this.hasTarget = true;
    }

    void LateUpdate()
    {
        if (!this.hasTarget)
            return;

        Vector3 desiredPosition = target.position + offset;
       

        desiredPosition.x = this.transform.position.x;
        desiredPosition.z = this.transform.position.z;


        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        //transform.LookAt(target);
    }
}
