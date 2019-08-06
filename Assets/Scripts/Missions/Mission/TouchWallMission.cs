using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchWallMission : Mission
{
    int meters = 0;

    public TouchWallMission(int _meters) : base()
    {
        this.localizedKey = "itchMission";
        this.meters = _meters;
    }


    public override void AddEvents()
    {
        EventsMan.OnTouchWallNMeters += Evaluate;
        EventsMan.OnNewGameStart += SetTargetItchMeters;
        EventsMan.OnGameOver += OnGameOver;
    }


    public void OnGameOver()
    {
        DataMan.Instance.missionsData.MissionItchMeterAcum += Game.Instance.touchWallDistanceMeter.meters;
    }


    public void Evaluate(int _meters)
    {
        if (ValidateMissionComplete(_meters))
            base.MissionComplete();
    }


    public void SetTargetItchMeters()
    {
        int newtarget = this.meters - DataMan.Instance.missionsData.MissionItchMeterAcum;
        Game.Instance.touchWallDistanceMeter.ReportOn(newtarget);
    }


    protected bool ValidateMissionComplete(int _meters)
    {
        return _meters + DataMan.Instance.missionsData.MissionItchMeterAcum == meters;
    }



    public override string GetString()
    {
        if (isComplete)
        {
            return I18N.Instance.GetLocalizedValue(localizedKey).Replace("/VALUE", this.meters.ToString());
        }
        else
        {
            string remaining = "";
            if (Game.Instance && !Game.Instance.isGameOver)
            {
                remaining = "\n" +
                I18N.Instance.GetLocalizedValue("remaining") + " " +
                (meters - (DataMan.Instance.missionsData.MissionItchMeterAcum +
                Game.Instance.touchWallDistanceMeter.meters)) +
                I18N.Instance.GetLocalizedValue("meters") + ".";
            }
            else
            {
                remaining = "\n" +
                I18N.Instance.GetLocalizedValue("remaining") + " " + 
                (meters - DataMan.Instance.missionsData.MissionItchMeterAcum) +
                I18N.Instance.GetLocalizedValue("meters") + ".";
            }

            return I18N.Instance.GetLocalizedValue(localizedKey).Replace("/VALUE", this.meters.ToString()) + remaining;
        }
    }

    public override void OnMissionComplete()
    {
        DataMan.Instance.missionsData.MissionItchMeterAcum = 0;
        NotificationMan.Instance.Show_MissionCompleteNotification(this.GetString());
        //RemoveEvents();
    }

    public override void RemoveEvents()
    {
        EventsMan.OnTouchWallNMeters -= Evaluate;
        EventsMan.OnNewGameStart -= SetTargetItchMeters;
        EventsMan.OnGameOver -= OnGameOver;
    }

    public override void OnAddMission()
    {
        DataMan.Instance.missionsData.MissionItchMeterAcum = 0;
    }
}
