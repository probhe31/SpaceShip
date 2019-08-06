using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotCookieWithoutDieMission : Mission
{
    int lotCookies = 0;

    public override void OnAddMission()
    {
    }

    public LotCookieWithoutDieMission(int _lotCookies) : base()
    {
        this.localizedKey = "lotCookieMissionNoDie";
        this.lotCookies = _lotCookies;
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
        {
            MissionComplete();
        }
    }


    protected bool ValidateMissionComplete(int _specialCookies)
    {
        return _specialCookies == lotCookies;
    }


    public void SetTargetSpecialCookies()
    {
        Game.Instance.player.lotCookieSensor.ReportOnLotCookies(this.lotCookies);
    }

    public override string GetString()
    {
        return I18N.Instance.GetLocalizedValue(localizedKey).Replace("/VALUE", this.lotCookies.ToString());
    }

    public override void OnMissionComplete()
    {
        NotificationMan.Instance.Show_MissionCompleteNotification(this.GetString());
        //this.RemoveEvents();
    }
}
