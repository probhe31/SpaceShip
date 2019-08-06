using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Player player;
    Rigidbody rb;

    private void Start()
    {
        this.player = this.GetComponent<Player>();
        this.rb = this.GetComponent<Rigidbody>();
        this.rb.maxAngularVelocity = 8;
    }

    public void Traslate(Vector3 position)
    {
        this.rb.velocity = Vector3.zero;
        this.rb.angularVelocity = Vector3.zero;
        this.rb.MovePosition(position);
        this.rb.isKinematic = true;
    }

    public void OnDie()
    {
        this.rb.velocity = Vector3.zero;
        this.rb.angularVelocity = Vector3.zero;
        this.enabled = false;
    }

    public void OnRespawn(Vector3 position)
    {
        this.rb.isKinematic = false;
        this.rb.velocity = Vector3.zero;
        this.rb.angularVelocity = Vector3.zero;
        this.rb.MovePosition(position);
        this.enabled = true;
    }

    int dirX = 1;
    int dirZ = 1;

    private void FixedUpdate()
    {
        Vector3 newVel = this.rb.velocity;
        Vector3 newAngularVel = this.rb.angularVelocity;

        #region xMovement
        if (this.player.input.HorizontalAxis != 0)
        {
            newVel.x += this.player.input.HorizontalAxis * PlayerVars.acceleration * Time.fixedDeltaTime;
            if (this.player.input.HorizontalAxis > 0) dirX = 1; else dirX = -1;
            newAngularVel.y = newVel.x * 6;
            
        }
        else
        {
            if (newVel.x > 0)
            {
                newVel.x -= PlayerVars.dessaceleration * Time.fixedDeltaTime;
                if (newVel.x < 0)
                    newVel.x = 0;
            }
            else
            {
                newVel.x += PlayerVars.dessaceleration * Time.fixedDeltaTime;
                if (newVel.x > 0)
                    newVel.x = 0;
            }

            

        }

        #endregion

        #region yMovement
        if (this.player.input.VerticalAxis != 0)
        {
            newVel.z += this.player.input.VerticalAxis * PlayerVars.acceleration * Time.fixedDeltaTime;
            if (this.player.input.VerticalAxis > 0) dirZ = 1; else dirZ = -1;
            newAngularVel.x = newVel.z * 6;

        }
        else
        {
            if (newVel.z > 0)
            {
                newVel.z -= PlayerVars.dessaceleration * Time.fixedDeltaTime;
                if (newVel.z < 0)
                    newVel.z = 0;
            }
            else
            {
                newVel.z += PlayerVars.dessaceleration * Time.fixedDeltaTime;
                if (newVel.z > 0)
                    newVel.z = 0;
            }
            
        }
        #endregion

        newVel.y = PlayerVars.maxFallSpeed;

        if (newVel.x > PlayerVars.maxMoveSpeed)
            newVel.x = PlayerVars.maxMoveSpeed;
        else if (newVel.x < -PlayerVars.maxMoveSpeed)
            newVel.x = -PlayerVars.maxMoveSpeed;

        if (newVel.z > PlayerVars.maxMoveSpeed)
            newVel.z = PlayerVars.maxMoveSpeed;
        else if (newVel.z < -PlayerVars.maxMoveSpeed)
            newVel.z = -PlayerVars.maxMoveSpeed;


        if(this.player.input.HorizontalAxis == 0)
        {
            newAngularVel.y = dirX * 2.5f;
        }

        if (this.player.input.VerticalAxis == 0)
        {
            newAngularVel.x = dirZ * 2.5f;
        }

        this.rb.angularVelocity = newAngularVel;     
        this.rb.velocity = newVel;
        
        Game.Instance.fallDistanceMeter.UpdateMeters(this.transform.position.y);

        

    }



   
}
