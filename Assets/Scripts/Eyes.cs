using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    public Eye eyeL;
    public Eye eyeR;
    /*float c;
    float t;

    public void Initialize()
    {
        eyeL.RandomizePupil();
        eyeR.RandomizePupil();
        this.c = 0;
        this.t = Random.Range(5, 11) / 10;
    }

    public void Blink()
    {
        this.c += Time.deltaTime;
        if (this.c > this.t)
        {
            this.c = 0;
            eyeL.Blink();
            eyeR.Blink();
        }
    }*/

    public void Initialize()
    {
        eyeL.Initialize();
        eyeR.Initialize();
    }
}
