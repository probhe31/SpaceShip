using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyUpgradesBuyerAchievement : Achievement
{

    public CrazyUpgradesBuyerAchievement(Money _reward)
    {
        this.localizedKey = "achv17_name";
        this.localizedKeyDesc = "achv17_descr";
        this.reward = _reward;
    }


    public override void AddEvents()
    {
        EventsMan.OnBuyUpgradeN += Evaluate;
    }


    void Evaluate(int idUpgrade)
    {
        bool res = true;
        for (int i = 0; i < DataMan.Instance.upgradesData.upgrades.Count; i++)
        {
            res = DataMan.Instance.upgradesData.upgrades[i].Status == ItemState.Bought;
        }

        if (res) 
            Complete();
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
        EventsMan.OnBuyUpgradeN -= Evaluate;
    }
}
