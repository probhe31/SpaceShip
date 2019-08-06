using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : BlockElement
{
    public float firingRate = 1;
    float c_firingRate = 0;
    public Transform spawningPoint;


    public void Initialize(Block _block, int direction)
    {
        //this.transform.rotation = Quaternion.identity;
        //this.transform.eulerAngles = Vector3.zero;

       
        base.Initialize(_block);
        /*if(direction == 1)
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 135, 0));

        if (direction == 2)
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 45, 0));*/

        this.transform.rotation = Quaternion.identity;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 135, 0));

    }

    public override void OnInitialize()
    {
        base.OnInitialize();
        c_firingRate = firingRate;
    }

    private void Update()
    {
        this.c_firingRate += Time.deltaTime;
        if (this.c_firingRate > this.firingRate)
        {
            this.c_firingRate = 0;
            GenerateBullet();
        }
    } 

    void GenerateBullet()
    {
        GameObject bullet = TrashMan.spawn("fire_bullet", spawningPoint.position);
        bullet.transform.rotation = spawningPoint.rotation;
        bullet.GetComponent<Bullet>().Initialize(block);

    }
}
