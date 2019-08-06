
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DistanceMeter
{
    public int meters = 0;
    List<int> reportOn = new List<int>();

    public void UpdateMeters(float _newpos)
    {
        this.meters = Mathf.Abs(Mathf.RoundToInt(_newpos * 0.25f));
        OnUpdateMeters();
        for (int i = 0; i < reportOn.Count; i++)
        {
            if (this.reportOn[i] == this.meters)
            {
                this.reportOn.RemoveAt(i);
                DistanceReached();
            }
        }
    }

    public virtual void OnUpdateMeters()
    {

    }


    public abstract void DistanceReached();


    public void ReportOn(int _reportOn)
    {
        this.reportOn.Add(_reportOn);
    }

}
