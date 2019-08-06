using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLightSensor : MonoBehaviour
{
    AccumulatorMan accumulatorMan;
    List<int> reportOnRedLights = new List<int>();

    private void Start()
    {
        this.accumulatorMan = AccumulatorMan.Instance;
    }

   
    public void ReportOnRedLight(int _reportOn)
    {
        this.reportOnRedLights.Add(_reportOn);
    }

    public void EatRedLight(RedLight redLight)
    {
        this.accumulatorMan.redLights.Add(1);
        redLight.OnEat();

        for (int i = 0; i < reportOnRedLights.Count; i++)
        {
            if (this.reportOnRedLights[i] == this.accumulatorMan.redLights.AmountThisGame)
            {
                this.reportOnRedLights.RemoveAt(i);
                EventsMan.Instance.Call_OnTouchNRedLights(this.accumulatorMan.redLights.AmountThisGame);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.RedLight))
        {
            EatRedLight(other.gameObject.GetComponent<RedLight>());
            return;
        }
    }
}
