using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDistanceMeter : DistanceMeter
{
    public override void DistanceReached()
    {
        EventsMan.Instance.Call_OnFallNMeters(this.meters);
    }

    public override void OnUpdateMeters()
    {
        Game.Instance.uiGameScreen.hud.score.SetText(this.meters + "m");

    }
}
