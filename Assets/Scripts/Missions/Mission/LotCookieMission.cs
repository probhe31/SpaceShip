using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotCookieMission : Mission
{
    int lotCookies = 0;


    public LotCookieMission(int _lotCookies) : base()
    {
        this.localizedKey = "lotCookieMission";
        this.lotCookies = _lotCookies;
    }

    public override void OnAddMission()
    {
    }

    public override void AddEvents()
    {
        EventsMan.OnEatNSpecialCookies += Evaluate;
        EventsMan.OnNewGameStart += SetTargetSpecialCookies;
        EventsMan.OnGameOver += OnGameOver;
    }

    public override void RemoveEvents()
    {
        EventsMan.OnEatNSpecialCookies -= Evaluate;
        EventsMan.OnNewGameStart -= SetTargetSpecialCookies;
        EventsMan.OnGameOver -= OnGameOver;
    }


    public void OnGameOver()
    {
        DataMan.Instance.missionsData.MissionSpecialCookieAcum += EconomyMan.Instance.LotCookiesThisGame;
    }

    public void Evaluate(int _specialCookies)
    {
        if (ValidateMissionComplete(_specialCookies))
            MissionComplete();
    }


    public void SetTargetSpecialCookies()
    {
        int newtarget = this.lotCookies - DataMan.Instance.missionsData.MissionSpecialCookieAcum;
        Game.Instance.player.lotCookieSensor.ReportOnLotCookies(newtarget);
    }


    protected bool ValidateMissionComplete(int _specialCookies)
    {
        return _specialCookies + DataMan.Instance.missionsData.MissionCookieAcum == this.lotCookies;
    }



    public override string GetString()
    {
        return I18N.Instance.GetLocalizedValue(localizedKey).Replace("/VALUE", this.lotCookies.ToString());
    }

    public override void OnMissionComplete()
    {
        NotificationMan.Instance.Show_MissionCompleteNotification(this.GetString());
        //RemoveEvents();
    }
}
