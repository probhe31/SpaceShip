using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyRewardCompletionistAchievement : Achievement
{

    public DailyRewardCompletionistAchievement(Money reward)
    {
        this.localizedKey = "achv6_name";
        this.localizedKeyDesc = "achv6_descr";
    }


    public override void AddEvents()
    {
        EventsMan.OnCompleteDailyReward += Evaluate;
    }

    void Evaluate()
    {
        if (!DataMan.Instance.achievementsData.achievements[idAchievement].IsComplete)
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
        return I18N.Instance.GetLocalizedValue(localizedKeyDesc);
    }


    public override void RemoveEvents()
    {
        EventsMan.OnCompleteDailyReward -= Evaluate;
    }
}
