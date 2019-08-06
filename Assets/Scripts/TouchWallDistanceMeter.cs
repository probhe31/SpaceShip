using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchWallDistanceMeter : DistanceMeter
{
    public override void DistanceReached()
    {
        EventsMan.Instance.Call_OnTouchWallNMeters(this.meters);
    }
}
