using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyUpgradeMission : Mission
{
    int idUpgrade = 0;

    public BuyUpgradeMission(int _idUpgrade) : base()
    {
        this.localizedKey = "buyUpgradeMission";
        this.idUpgrade = _idUpgrade;
    }

    public override void OnAddMission()
    {
    }

    public override void AddEvents()
    {
        EventsMan.OnBuyUpgradeN += Evaluate;
    }


    public void Evaluate(int idUpgrade)
    {
        if (ValidateMissionComplete(idUpgrade))
            MissionComplete();
    }

    public override void OnMissionComplete()
    {
        NotificationMan.Instance.Show_MissionCompleteNotification(this.GetString());
        //RemoveEvents();
    }

    protected bool ValidateMissionComplete(int idUpgrade)
    {
        return DataMan.Instance.upgradesData.upgrades[idUpgrade].Status == ItemState.Bought;
    }

    public override void RemoveEvents()
    {
        EventsMan.OnBuyUpgradeN -= Evaluate;
    }
    
    public override string GetString()
    {
        return I18N.Instance.GetLocalizedValue(localizedKey).Replace("/VALUE",
            I18N.Instance.GetLocalizedValue(UpgradesMan.Instance.gameUpgrades.upgrades[idUpgrade].key_name));
    }

    
}
