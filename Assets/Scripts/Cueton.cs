using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cueton : Hazard
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Player))
        {
            this.gameObject.SetActive(false);
            Game.Instance.player.dieDetection.Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(Tags.Player))
        {
            this.gameObject.SetActive(false);
            Game.Instance.player.dieDetection.Die();


        }
    }
}