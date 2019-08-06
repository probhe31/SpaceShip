using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceDebug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float force = 100;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * force);
        }
    }
}
