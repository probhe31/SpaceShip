using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLight : BlockElement, IEateable
{

    public Material mat;
    public Material normalmat;


    public override void OnInitialize()
    {
        this.GetComponent<Renderer>().material = normalmat;
        this.GetComponent<BoxCollider>().enabled = true;

        base.OnInitialize();
    }

    public void OnEat()
    {
        this.GetComponent<Renderer>().material = mat;
        this.GetComponent<BoxCollider>().enabled = false;
        //this.gameObject.SetActive(false);
    }

}
