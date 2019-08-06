using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosivesExpertAchievement : Achievement
{
    public int explosives;

    public ExplosivesExpertAchievement(string nameKey, int _explosives, Money _reward)
    {
        this.localizedKey = nameKey;
        this.localizedKeyDesc = "achv10_descr";
        this.explosives = _explosives;
        this.reward = _reward;
    }

    public override void AddEvents()
    {
        EventsMan.OnGameOver += Evaluate;
    }

    void Evaluate()
    {
        DataMan.Instance.achievementsData.Explosives_Accumulator += 1;

        if (DataMan.Instance.achievementsData.Cookies_Accumulator >= this.explosives)
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
        return I18N.Instance.GetLocalizedValue(localizedKeyDesc).Replace("/VALUE", this.explosives.ToString());
    }


    public override void RemoveEvents()
    {
        EventsMan.OnGameOver -= Evaluate;
    }
}
