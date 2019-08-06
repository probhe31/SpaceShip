using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyRewardHunterAchievement : Achievement
{
    public int rewards;

    public DailyRewardHunterAchievement(string nameKey, int _rewards, Money _reward)
    {
        this.localizedKey = nameKey;
        this.localizedKeyDesc = "achv14_descr";
        this.rewards = _rewards;
        this.reward = _reward;
    }


    public override void AddEvents()
    {
        EventsMan.OnCollectDailyReward += Evaluate;
    }


    void Evaluate()
    {
        DataMan.Instance.achievementsData.Daily_Reward_Accumulator += 1;


        if (DataMan.Instance.achievementsData.Daily_Reward_Accumulator >= rewards)
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
        return I18N.Instance.GetLocalizedValue(localizedKeyDesc).Replace("/VALUE", this.rewards.ToString());
    }


    public override void RemoveEvents()
    {
        EventsMan.OnCompleteDailyReward -= Evaluate;
    }
}
