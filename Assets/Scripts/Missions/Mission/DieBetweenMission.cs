using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieBetweenMission : Mission
{
    int meters_range_init = 0;
    int meters_range_end = 0;


    public override void OnAddMission()
    {
    }

    public DieBetweenMission(int _meters_a, int _meters_b) : base()
    {
        this.localizedKey = "dieBetweenMission";
        this.meters_range_init = _meters_a;
        this.meters_range_end = _meters_b;
    }

    public override void AddEvents()
    {
        EventsMan.OnGameOver += Evaluate;

    }

    public void Evaluate()
    {
        if (ValidateMissionComplete(Game.Instance.fallDistanceMeter.meters))
            MissionComplete();
    }

    

    protected bool ValidateMissionComplete(int _meters)
    {
        return _meters >= this.meters_range_init && _meters <= this.meters_range_end;
    }

    public override string GetString()
    {
        return I18N.Instance.GetLocalizedValue(localizedKey).Replace("/VALUE", 
            (this.meters_range_init.ToString()+" y "+ this.meters_range_end.ToString()));
    }

    public override void OnMissionComplete()
    {
        NotificationMan.Instance.Show_MissionCompleteNotification(this.GetString());
        //this.RemoveEvents();
    }

    public override void RemoveEvents()
    {
        EventsMan.OnGameOver -= Evaluate;
    }


}
