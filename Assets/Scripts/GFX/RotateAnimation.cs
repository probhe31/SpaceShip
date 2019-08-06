using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnimation : MonoBehaviour
{
    public float rotationSpeed = 150;
    public Vector3 direction;
    void Update()
    {
        transform.Rotate(direction, rotationSpeed * Time.deltaTime);
    }
}
