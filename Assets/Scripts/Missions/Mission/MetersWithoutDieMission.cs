using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetersWithoutDieMission : Mission
{
    int meters = 0;

    public MetersWithoutDieMission(int _meters) : base()
    {
        this.localizedKey = "meterMissionNoDie";
        this.meters = _meters;
    }

    public override void OnAddMission()
    {
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
        if(ValidateMissionComplete(_meters))
            MissionComplete();
    }

    public void SetTargetMeters()
    {
        Game.Instance.fallDistanceMeter.ReportOn(meters);
    }

    protected bool ValidateMissionComplete(int _meters)
    {
        return _meters == meters;
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
            I18N.Instance.GetLocalizedValue("remaining") + " " + (meters - Game.Instance.fallDistanceMeter.meters) +
            I18N.Instance.GetLocalizedValue("meters") + ".";
            }            

            return I18N.Instance.GetLocalizedValue(localizedKey).Replace("/VALUE", this.meters.ToString()) + remaining;
        }
    }

    public override void OnMissionComplete()
    {       
        NotificationMan.Instance.Show_MissionCompleteNotification(this.GetString());
        //this.RemoveEvents();
    }

    public override void RemoveEvents()
    {
        EventsMan.OnFallNMeters -= Evaluate;
        EventsMan.OnNewGameStart -= SetTargetMeters;
        EventsMan.OnGameOver -= OnGameOver;
    }


}
