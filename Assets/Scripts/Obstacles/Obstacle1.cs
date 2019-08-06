using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle1 : Obstacle
{

    public override void OnInitialize()
    {
        base.OnInitialize();
        int probRotation = Random.Range(0, 100);

        if(probRotation < 50)
        {
            this.transform.localRotation = Quaternion.Euler(new Vector3(90, 0, 0));
        }
        else
        {
            this.transform.localRotation = Quaternion.Euler(new Vector3(180, 90, 90));
        }

        base.OnInitialize();
    }
    
}
