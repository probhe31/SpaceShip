using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieDetection : MonoBehaviour
{
    float timeToDetect = 0.3f;
    float cTimeToDetect = 0;
    public Rigidbody myRb;
    public bool isDie = false;
    public Transform followPlayer;

    private void Start()
    {
        myRb = this.GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(Tags.WallObstacle) || collision.collider.CompareTag(Tags.Hazard))
        {
            Die();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.Hazard))
        {
            Die();
        }
    }
   

    public void Die()
    {
        if (this.isDie)
            return;

        this.isDie = true;

        SmoothFollowCamera.Instance.ShakeCamera(0.5f, 0.04f);

        //this.isDie = true;
       
        this.myRb.angularVelocity = Vector3.zero;
        this.myRb.velocity = Vector3.zero;

        //this.GetComponent<Player>().Die();
        Game.Instance.player.Die();

        StartCoroutine(WaitingToGoGameOver());
    }


    IEnumerator WaitingToGoGameOver()
    {
        yield return new WaitForSeconds(1f);
        Game.Instance.GameOver();
    }
}
