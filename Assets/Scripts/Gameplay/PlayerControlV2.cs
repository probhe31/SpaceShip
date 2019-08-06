using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlV2 : MonoBehaviour
{

    public Rigidbody mainRB;

    float acceleration = 14;
    float dessaceleration = 6;
    float maxMoveSpeed = 14;
    float maxFallSpeed = 52;


    private void Awake()
    {
        this.mainRB.angularVelocity = Random.insideUnitSphere * 10000f;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        

    }

    private void FixedUpdate()
    {
        Move();
    }

    float h;
    float v;
    
    Vector3 vel;

    void Move()
    {
        this.h = 0;
        this.v = 0;
        //this.h = Input.acceleration.x;
        //this.v = Input.acceleration.y + 0.5f;

        this.h = Input.GetAxisRaw("Horizontal") * 0.3f;
        this.v = Input.GetAxisRaw("Vertical") * 0.3f;


        this.vel = this.mainRB.velocity;
        if (this.h != 0)
        {
            this.vel.x = h * acceleration;
        }
        else if (this.vel.x != 0)
        {
            //desacelerando
            if(this.vel.x > 0)
            {
                this.vel.x -= this.dessaceleration * Time.fixedDeltaTime;
                if (this.vel.x < 0)
                    this.vel.x = 0;
            }
            else
            {
                this.vel.x += this.dessaceleration * Time.fixedDeltaTime;
                if (this.vel.x > 0)
                    this.vel.x = 0;

            }
        }

        if (this.v != 0)
        {
            this.vel.z = v * acceleration;
        }
        else if (this.vel.z != 0)
        {
            //desacelerando
            if (this.vel.z > 0)
            {
                this.vel.z -= this.dessaceleration * Time.fixedDeltaTime;
                if (this.vel.z < 0)
                    this.vel.z = 0;
            }
            else
            {
                this.vel.z += this.dessaceleration * Time.fixedDeltaTime;
                if (this.vel.z > 0)
                    this.vel.z = 0;

            }
        }


        if (this.vel.x > this.maxMoveSpeed)
            this.vel.x = this.maxMoveSpeed;
        else if (this.vel.x < -this.maxMoveSpeed)
            this.vel.x = -this.maxMoveSpeed;

        if (this.vel.z > this.maxMoveSpeed)
            this.vel.z = this.maxMoveSpeed;
        else if (this.vel.z < -this.maxMoveSpeed)
            this.vel.z = -this.maxMoveSpeed;

        if(this.vel.y < -maxFallSpeed)
        {
            this.vel.y = -this.maxFallSpeed;
        }

        this.mainRB.velocity = vel;
        Vector3 angularvel = this.mainRB.angularVelocity;
        angularvel.y = this.vel.x;
        angularvel.x = this.vel.z;
        this.mainRB.angularVelocity = angularvel;

    }

}
