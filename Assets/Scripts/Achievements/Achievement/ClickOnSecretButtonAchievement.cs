using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnSecretButtonAchievement : Achievement
{
    public ClickOnSecretButtonAchievement(Money _reward)
    {
        this.localizedKey = "achv18_name";
        this.localizedKeyDesc = "achv18_descr";
        this.reward = _reward;
    }


    public override void AddEvents()
    {
        EventsMan.OnFoundSecretButton += Evaluate;
    }


    void Evaluate()
    {
        bool res = true;
        for (int i = 0; i < Constants.num_secret_buttons; i++)
        {
            res = DataMan.Instance.achievementsData.secrets[i].WasFound;
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
        EventsMan.OnFoundSecretButton -= Evaluate;
    }
}
