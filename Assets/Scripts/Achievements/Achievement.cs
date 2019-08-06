using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Achievement: IEventeable
{
    public int idAchievement;
    protected string localizedKey;
    protected string localizedKeyDesc;
    public Sprite insignia;
    protected bool isComplete = false;
    protected bool isCollected = false;
    public int level = 0;
    public Money reward;


    public bool IsComplete
    {
        get
        {
            return isComplete;
        }
        private set
        {
            isComplete = value;
            DataMan.Instance.achievementsData.achievements[idAchievement].IsComplete = isComplete;
        }
    }


    public bool IsCollected
    {
        get
        {
            return isCollected;
        }
        private set
        {
            isCollected = value;
            DataMan.Instance.achievementsData.achievements[idAchievement].IsCollected = isCollected;
        }
    }


    public void Collect()
    {
        if (IsComplete)
        {
            IsCollected = true;

            EconomyMan.Instance.Add(reward);
        }
    }


    protected void Complete()
    {
        this.IsComplete= true;
        this.IsCollected = false;

        AchievementMan.Instance.ReportCompleteAchievement(this.idAchievement);
        OnComplete();
        RemoveEvents();
        
    }


    public void Load(int _idAchievement, bool _isCollected,bool _isComplete)
    {
        this.idAchievement = _idAchievement;
        this.isComplete = _isComplete;
        this.isCollected = _isCollected;

        if (!this.isComplete)
        {
            AddEvents();
        }
    }


    public abstract void AddEvents();
    public abstract void RemoveEvents();
    public abstract string GetName();
    public abstract string GetDescription();
    public virtual void OnComplete() { }
}

