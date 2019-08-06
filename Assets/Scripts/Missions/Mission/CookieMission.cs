using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieMission : Mission
{
    int cookies = 0;

    public CookieMission(int _cookies) : base()
    {
        this.localizedKey = "cookiesMission";
        this.cookies = _cookies;
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


    public void SetTargetCookies()
    {
        int newtarget = this.cookies - DataMan.Instance.missionsData.MissionCookieAcum;
        Game.Instance.player.cookieSensor.ReportOnCookies(newtarget);
    }


    protected bool ValidateMissionComplete(int _cookies)
    {
        return _cookies + DataMan.Instance.missionsData.MissionCookieAcum == this.cookies;
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
            I18N.Instance.GetLocalizedValue("remaining") + " " + (cookies - (DataMan.Instance.missionsData.MissionCookieAcum + EconomyMan.Instance.CookiesThisGame)) +
            I18N.Instance.GetLocalizedValue("cookies") + ".";
            }
            else
            {
                remaining = "\n" +
            I18N.Instance.GetLocalizedValue("remaining") + " " + (cookies - DataMan.Instance.missionsData.MissionCookieAcum) +
            I18N.Instance.GetLocalizedValue("cookies") + ".";
            }

            return I18N.Instance.GetLocalizedValue(localizedKey).Replace("/VALUE", this.cookies.ToString()) + remaining;
        }

    }

    public override void OnMissionComplete()
    {
        DataMan.Instance.missionsData.MissionCookieAcum = 0;
        NotificationMan.Instance.Show_MissionCompleteNotification(this.GetString());
        //RemoveEvents();
    }


    public override void OnAddMission()
    {
        DataMan.Instance.missionsData.MissionCookieAcum = 0;
    }

}
