using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody myRigidbody;

    public void Initialize()
    {
        this.GetComponent<SphereCollider>().enabled = true;
        myRigidbody = this.GetComponent<Rigidbody>();
        myRigidbody.isKinematic = true;
        transform.rotation = Random.rotation;
    }

    public void Throw(Vector3 force)
    {
        myRigidbody.isKinematic = false;
        myRigidbody.AddForce(force);
        myRigidbody.maxAngularVelocity = 20.0f;
        myRigidbody.AddTorque(new Vector3(0, 0, 2.0f));
    }

}
