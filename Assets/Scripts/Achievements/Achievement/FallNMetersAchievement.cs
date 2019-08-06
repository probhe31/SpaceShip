using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallNMetersAchievement : Achievement
{
    public int meters;

    public FallNMetersAchievement(string nameKey, int _meters, Money _reward)
    {
        this.localizedKey = nameKey;
        this.localizedKeyDesc = "achv7_descr";
        this.meters = _meters;
        this.reward = _reward;
    }


    public override void AddEvents()
    {
        EventsMan.OnGameOver += Evaluate;
    }


    void Evaluate()
    {
        DataMan.Instance.achievementsData.Fall_Meters_Accumulator += Game.Instance.fallDistanceMeter.meters;

        if (DataMan.Instance.achievementsData.Fall_Meters_Accumulator >= this.meters)
        {
            this.Complete();
        }
    }


    public override string GetName()
    {
        return I18N.Instance.GetLocalizedValue(localizedKey);
    }


    public override string GetDescription()
    {
        return I18N.Instance.GetLocalizedValue(localizedKeyDesc).Replace("/VALUE", this.meters.ToString());
    }

    
    public override void RemoveEvents()
    {
        EventsMan.OnGameOver -= Evaluate;
    }
}
