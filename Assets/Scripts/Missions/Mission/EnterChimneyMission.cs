using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterChimneyMission : Mission
{
    int times = 0;

    public EnterChimneyMission(int _times) : base()
    {
        this.localizedKey = "chimneyFallMission";
        this.times = _times;
    }

    public override void OnAddMission()
    {
        DataMan.Instance.missionsData.MissionEnterChimneyAcum = 0;
    }


    public override void AddEvents()
    {
        EventsMan.OnNewGameStart += Evaluate;
    }


    public override void RemoveEvents()
    {
        EventsMan.OnNewGameStart -= Evaluate;
    }

    void Evaluate()
    {
        DataMan.Instance.missionsData.MissionEnterChimneyAcum++;

        if (DataMan.Instance.missionsData.MissionEnterChimneyAcum >= times)
        {
            this.MissionComplete();
        }
        
    }


    public override string GetString()
    {
        if (isComplete)
        {
            return I18N.Instance.GetLocalizedValue(localizedKey).Replace("/VALUE", this.times.ToString());
        }
        else
        {
            string remaining = "\n" +
            I18N.Instance.GetLocalizedValue("remaining") + " " + (times - (DataMan.Instance.missionsData.MissionEnterChimneyAcum)) +
            " " + I18N.Instance.GetLocalizedValue("times") + ".";

            return I18N.Instance.GetLocalizedValue(localizedKey).Replace("/VALUE", this.times.ToString()) + remaining;
        }
    }

    public override void OnMissionComplete()
    {
        DataMan.Instance.missionsData.MissionEnterChimneyAcum = 0;
        NotificationMan.Instance.Show_MissionCompleteNotification(this.GetString());
        //RemoveEvents();
    }

    
}
