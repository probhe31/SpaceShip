using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticToPlayer : MonoBehaviour
{
    bool attracted = false;
    float probability = 10;

    public bool IsAtrracted
    {
        get
        {
            return attracted;
        }
    }


    public void Initialize()
    {
        this.enabled = true;
        this.attracted = false;
        this.probability = UpgradesMan.Instance.ProbabilityMagneticCookies;
    }

    public void Remove()
    {
        this.enabled = false;
        this.attracted = false;
    }


    private void Update()
    {
        if (!attracted && Physics.CheckSphere(this.transform.position, 0.35f, Constants.magneticCookiesLM))
        {
           attracted = true;
        }

        if (attracted)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, Game.Instance.player.transform.position, 10 * Time.deltaTime);
        }
    }
    
}
