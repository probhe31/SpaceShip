using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mission:IEventeable
{
    public int idMission;
    protected string localizedKey;    
    protected bool isComplete = false;
    
    public bool IsMissionComplete
    {
        get
        {
            return isComplete;
        }
        set
        {
            isComplete = value;
        }
    }


    protected void MissionComplete()
    {
        MissionMan.Instance.ReportCompleteMission(this.idMission);
        this.isComplete = true;
        OnMissionComplete();
        RemoveEvents();
    }

   
    public void LoadMission(int _idMission, bool _isComplete)
    {
        this.idMission = _idMission;
        this.isComplete = _isComplete;
        if (!this.isComplete)
        {
            AddEvents();
        }
    }

    
    public abstract void AddEvents();
    public abstract void RemoveEvents();
    public abstract string GetString();
    public abstract void OnMissionComplete();
    public abstract void OnAddMission();
    
}