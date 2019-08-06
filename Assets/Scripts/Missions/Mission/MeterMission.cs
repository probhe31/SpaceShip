using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterMission : Mission
{
    int meters = 0;

    public MeterMission(int _meters) : base()
    {
        this.localizedKey = "meterMission";
        this.meters = _meters;
    }

    public override void AddEvents()
    {
        EventsMan.OnFallNMeters += Evaluate;
        EventsMan.OnNewGameStart += SetTargetMeters;
        EventsMan.OnGameOver += OnGameOver;
    }


    public void OnGameOver()
    {
        DataMan.Instance.missionsData.MissionMeterAcum += Game.Instance.fallDistanceMeter.meters;
    }


    public void Evaluate(int _meters)
    {
        if (ValidateMissionComplete(_meters))
            MissionComplete();
    }


    public void SetTargetMeters()
    {
        int newtarget = this.meters - DataMan.Instance.missionsData.MissionMeterAcum;
        Game.Instance.fallDistanceMeter.ReportOn(newtarget);
    }


    protected bool ValidateMissionComplete(int _meters)
    {
        return _meters+DataMan.Instance.missionsData.MissionMeterAcum == meters;
    }



    public override string GetString()
    {
        if (isComplete){
            return I18N.Instance.GetLocalizedValue(localizedKey).Replace("/VALUE", this.meters.ToString());
        }
        else
        {
            string remaining = "";
            if (Game.Instance && !Game.Instance.isGameOver)
            {
                remaining = "\n" +
            I18N.Instance.GetLocalizedValue("remaining") + " " + (meters - (DataMan.Instance.missionsData.MissionMeterAcum + Game.Instance.fallDistanceMeter.meters)) +
            I18N.Instance.GetLocalizedValue("meters") + ".";
            }
            else
            {
                remaining = "\n" +
            I18N.Instance.GetLocalizedValue("remaining") + " " + (meters - DataMan.Instance.missionsData.MissionMeterAcum) +
            I18N.Instance.GetLocalizedValue("meters") + ".";
            }

            return I18N.Instance.GetLocalizedValue(localizedKey).Replace("/VALUE", this.meters.ToString()) + remaining;
        }
    }

    public override void OnMissionComplete()
    {
        DataMan.Instance.missionsData.MissionMeterAcum = 0;
        NotificationMan.Instance.Show_MissionCompleteNotification(this.GetString());
        //RemoveEvents();
    }

    public override void RemoveEvents()
    {
        EventsMan.OnFallNMeters -= Evaluate;
        EventsMan.OnNewGameStart -= SetTargetMeters;
        EventsMan.OnGameOver -= OnGameOver;
    }

    public override void OnAddMission()
    {
        DataMan.Instance.missionsData.MissionMeterAcum = 0;
    }
}
