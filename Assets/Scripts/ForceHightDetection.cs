using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceHightDetection : MonoBehaviour
{
    CharacterJoint characterjoint;

    private void Start()
    {
        this.characterjoint = this.GetComponent<CharacterJoint>();
    }

    float mag = 0;
    public float forceBreak = 50;
    public bool stop = false;

    void Update()
    {
        this.mag = this.characterjoint.currentForce.magnitude;
        Debug.Log("maginitrea " + mag);


        if (!stop)
            return;

        if (mag > forceBreak)
        {
            Debug.Log("bug in maginit " + mag);
            Debug.Break();

        }
    }
}
