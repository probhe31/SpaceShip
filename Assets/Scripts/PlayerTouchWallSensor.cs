using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchWallSensor : MonoBehaviour
{
    Rigidbody rb;
    public float acumTouchWallMeters = 0;
    bool touchingWall = false;
    bool justTouchWall = false;
    float lastTouchWallYPosition;
    RaycastHit raycasthit;
    public ParticleSystem touchWallParticles;


    private void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        Ray newray1 = new Ray(this.rb.position, new Vector3(0.5f, 0, 0.5f));
        Ray newray2 = new Ray(this.rb.position, new Vector3(-0.5f, 0, 0.5f));
        Ray newray3 = new Ray(this.rb.position, new Vector3(-0.5f, 0, -0.5f));
        Ray newray4 = new Ray(this.rb.position, new Vector3(0.5f, 0, -0.5f));

        this.justTouchWall = touchingWall;

        if (Physics.Raycast(newray1, out raycasthit, 0.45f, PlayerVars.wallsLM) || Physics.Raycast(newray2, out raycasthit, 0.45f, PlayerVars.wallsLM)
            || Physics.Raycast(newray3, out raycasthit, 0.45f, PlayerVars.wallsLM) || Physics.Raycast(newray4, out raycasthit, 0.45f, PlayerVars.wallsLM))
        {
            acumTouchWallMeters += Mathf.Abs(lastTouchWallYPosition - this.transform.position.y);
        }

        lastTouchWallYPosition = this.transform.position.y;


        Game.Instance.touchWallDistanceMeter.UpdateMeters(acumTouchWallMeters);
    }
}
