using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLightMission : Mission
{
    int lights = 0;

    public RedLightMission(int _lights) : base()
    {
        this.localizedKey = "lightMission";
        this.lights = _lights;
    }

    public override void AddEvents()
    {
        EventsMan.OnTouchNRedLights += Evaluate;
        EventsMan.OnNewGameStart += SetTargetRedLights;
        EventsMan.OnGameOver += OnGameOver;
    }


    public override void RemoveEvents()
    {
        EventsMan.OnTouchNRedLights -= Evaluate;
        EventsMan.OnNewGameStart -= SetTargetRedLights;
        EventsMan.OnGameOver -= OnGameOver;
    }


    public void OnGameOver()
    {
        DataMan.Instance.missionsData.MissionRedLightAcum += AccumulatorMan.Instance.redLights.AmountThisGame;
    }

    public void Evaluate(int _lights)
    {
        if (ValidateMissionComplete(_lights))
            MissionComplete();
    }


    public void SetTargetRedLights()
    {
        int newtarget = this.lights - DataMan.Instance.missionsData.MissionRedLightAcum;
        Game.Instance.player.redLightSensor.ReportOnRedLight(newtarget);
    }


    protected bool ValidateMissionComplete(int _lights)
    {
        return _lights + DataMan.Instance.missionsData.MissionRedLightAcum == this.lights;
    }



    public override string GetString()
    {
        if (isComplete)
        {
            return I18N.Instance.GetLocalizedValue(localizedKey).Replace("/VALUE", this.lights.ToString());
        }
        else
        {
            string remaining = "";
            if (Game.Instance && !Game.Instance.isGameOver)
            {
                remaining = "\n" +
            I18N.Instance.GetLocalizedValue("remaining") + " " + 
            (lights - (DataMan.Instance.missionsData.MissionRedLightAcum + AccumulatorMan.Instance.redLights.AmountThisGame)) +
            " " + I18N.Instance.GetLocalizedValue("lights") + ".";
            }
            else
            {
                remaining = "\n" +
            I18N.Instance.GetLocalizedValue("remaining") + " " + 
            (lights - DataMan.Instance.missionsData.MissionRedLightAcum) + " " +
            I18N.Instance.GetLocalizedValue("lights") + ".";
            }

            return I18N.Instance.GetLocalizedValue(localizedKey).Replace("/VALUE", this.lights.ToString()) + remaining;
        }

    }

    public override void OnMissionComplete()
    {
        DataMan.Instance.missionsData.MissionRedLightAcum = 0;
        NotificationMan.Instance.Show_MissionCompleteNotification(this.GetString());
    }


    public override void OnAddMission()
    {
        DataMan.Instance.missionsData.MissionRedLightAcum = 0;
    }
}
