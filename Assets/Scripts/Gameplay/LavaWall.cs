using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaWall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(Tags.Player))
        {
            this.gameObject.SetActive(false);
            Game.Instance.player.dieDetection.Die();
        }
    }
}
