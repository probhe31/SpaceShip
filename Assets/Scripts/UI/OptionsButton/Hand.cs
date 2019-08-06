using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public LayerMask walls;
    public Rigidbody rb;


    private void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //if (Physics.Raycast(new Ray(this.transform.position, Vector3.down), 0.2f, walls))
        if (Physics.CheckSphere(this.transform.position, 0.2f, walls))
        {
            //Debug.Log("adding force");
            //this.rb.angularVelocity+=Vector3.left*8000.0f;
            this.rb.AddTorque(new Vector3(500, 0, 0));
            Vector3 v = this.rb.velocity;
            v.y = 0;
            this.rb.velocity = v;
            //Debug.Break();
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(Tags.WallObstacle))
        {
            collision.collider.GetComponent<Collider>().enabled = false;
            Debug.Break();
        }
    }*/
}
