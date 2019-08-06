using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieWithoutDieMission : Mission
{
    int cookies = 0;

    public CookieWithoutDieMission(int _cookies) : base()
    {
        this.localizedKey = "cookiesMissionNoDie";
        this.cookies = _cookies;
    }

    public override void OnAddMission()
    {
    }

    public override void AddEvents()
    {
        EventsMan.OnEatNCookies += Evaluate;
        EventsMan.OnNewGameStart += SetTargetCookies;
        EventsMan.OnGameOver += OnGameOver;
    }

    public override void RemoveEvents()
    {
        EventsMan.OnEatNCookies -= Evaluate;
        EventsMan.OnNewGameStart -= SetTargetCookies;
        EventsMan.OnGameOver -= OnGameOver;
    }


    public void OnGameOver()
    {
        DataMan.Instance.missionsData.MissionCookieAcum += EconomyMan.Instance.CookiesThisGame;
    }


    public void Evaluate(int _cookies)
    {
        if (ValidateMissionComplete(_cookies))
            MissionComplete();
    }


    protected bool ValidateMissionComplete(int _cookies)
    {
        return _cookies == cookies;
    }


    public void SetTargetCookies()
    {
        Game.Instance.player.cookieSensor.ReportOnCookies(cookies);
    }

    public override string GetString()
    {
        //return I18N.Instance.GetLocalizedValue(localizedKey).Replace("/VALUE", this.cookies.ToString());
        if (isComplete)
        {
            return I18N.Instance.GetLocalizedValue(localizedKey).Replace("/VALUE", this.cookies.ToString());
        }
        else
        {
            string remaining = "";

            if (Game.Instance && !Game.Instance.isGameOver)
            {
                remaining = "\n" +
            I18N.Instance.GetLocalizedValue("remaining") + " " + (cookies - EconomyMan.Instance.CookiesThisGame) +
            I18N.Instance.GetLocalizedValue("cookies") + ".";
            }

            return I18N.Instance.GetLocalizedValue(localizedKey).Replace("/VALUE", this.cookies.ToString()) + remaining;
        }
    }

    public override void OnMissionComplete()
    {
        NotificationMan.Instance.Show_MissionCompleteNotification(this.GetString());
        //this.RemoveEvents();
    }

    


}