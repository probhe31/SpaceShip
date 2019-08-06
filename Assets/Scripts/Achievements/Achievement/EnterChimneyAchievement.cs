using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterChimneyAchievement : Achievement
{
    public int numEnter;

    public EnterChimneyAchievement(string nameKey, int _numEnter, Money _reward)
    {
        this.localizedKey = nameKey;
        this.localizedKeyDesc = "achv1_descr";
        this.numEnter = _numEnter;
        this.reward = _reward;
    }

    public override void AddEvents()
    {
        EventsMan.OnNewGameStart += Evaluate;
    }

    void Evaluate()
    {
        DataMan.Instance.achievementsData.Enter_Chimney_Accumulator++;

        if (DataMan.Instance.achievementsData.Enter_Chimney_Accumulator >= this.numEnter)
        {
            this.Complete();
            GooglePlayMan.Instance.UpdateAchievement();
        }

    }

    

    public override string GetName()
    {
        return I18N.Instance.GetLocalizedValue(localizedKey);
    }

    public override string GetDescription()
    {
        return I18N.Instance.GetLocalizedValue(localizedKeyDesc).Replace("/VALUE", this.numEnter.ToString());
    }


    public override void RemoveEvents()
    {
        EventsMan.OnNewGameStart -= Evaluate;
    }
}
