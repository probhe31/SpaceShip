using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle3 : Obstacle
{
    public override void OnInitialize()
    {
        this.transform.localRotation = Quaternion.Euler(new Vector3(90, 0, 0));
        base.OnInitialize();
    }
}