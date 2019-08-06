using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Rigidbody rb;
    Vector3 rangularvel;
    private void OnEnable()
    {
        rb = this.GetComponent<Rigidbody>();


        this.rangularvel = Random.insideUnitSphere * 10f;
    }
    public void OnExplode()
    {
        TrashMan.despawn(this.gameObject);
    }

    private void Update()
    {
        Vector3 newvel = rb.velocity;
        newvel.y = -16;
        rb.velocity = newvel;
        this.rb.angularVelocity = rangularvel;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IExplotable>() != null)
        {
            OnExplode();
            other.gameObject.GetComponent<IExplotable>().OnExplode();
        }
    }
}
