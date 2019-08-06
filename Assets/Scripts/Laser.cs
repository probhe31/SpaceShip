using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Laser : Hazard
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Player))
        {
            Game.Instance.player.dieDetection.Die();
        }
    }

}