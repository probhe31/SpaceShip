using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatNCookiesAchievement : Achievement
{
    public int cookies;

    public EatNCookiesAchievement(string nameKey, int _cookies, Money _reward)
    {
        this.localizedKey = nameKey;
        this.localizedKeyDesc = "achv10_descr";
        this.cookies = _cookies;
        this.reward = _reward;
    }

    public override void AddEvents()
    {
        EventsMan.OnGameOver += Evaluate;
    }

    void Evaluate()
    {
        DataMan.Instance.achievementsData.Cookies_Accumulator += EconomyMan.Instance.CookiesThisGame;

        if (DataMan.Instance.achievementsData.Cookies_Accumulator >= this.cookies)
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
        return I18N.Instance.GetLocalizedValue(localizedKeyDesc).Replace("/VALUE", this.cookies.ToString());
    }


    public override void RemoveEvents()
    {
        EventsMan.OnGameOver -= Evaluate;
    }
}
