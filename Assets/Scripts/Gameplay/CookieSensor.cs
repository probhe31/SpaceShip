using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieSensor : MonoBehaviour
{
    EconomyMan economyMan;
    List<int> reportOnCookies = new List<int>();

    private void Start()
    {
        this.economyMan = EconomyMan.Instance;
    }

    public void ReportOnCookies(int _reportOn)
    {
        this.reportOnCookies.Add(_reportOn);
    }

    public void EatImprovedCookie(ImprovedCookie improvedCookie)
    {
        this.economyMan.AddCookiesFromFalling(Constants.amount_improved_cookies);
        improvedCookie.OnEat();
        Game.Instance.uiGameScreen.hud.SetCookies(this.economyMan.Cookies);
        GameObject p = TrashMan.spawn("eat_cookie", this.transform.position);
        p.transform.eulerAngles = new Vector3(-90, 0, 0);
        p.GetComponent<ParticleSystem>().Play();

        for (int i = 0; i < reportOnCookies.Count; i++)
        {
            if (this.reportOnCookies[i] == EconomyMan.Instance.CookiesThisGame)
            {
                this.reportOnCookies.RemoveAt(i);
                EventsMan.Instance.Call_OnEatNCookies(EconomyMan.Instance.CookiesThisGame);
            }
        }
    }

    public void EatCookie(Cookie cookie)
    {
        this.economyMan.AddCookiesFromFalling(1);
        cookie.OnEat();
        Game.Instance.uiGameScreen.hud.SetCookies(this.economyMan.Cookies);
        GameObject p = TrashMan.spawn("eat_cookie", this.transform.position);
        p.transform.eulerAngles = new Vector3(-90, 0, 0);
        p.GetComponent<ParticleSystem>().Play();

        for (int i = 0; i < reportOnCookies.Count; i++)
        {
            if (this.reportOnCookies[i] == EconomyMan.Instance.CookiesThisGame)
            {
                this.reportOnCookies.RemoveAt(i);
                EventsMan.Instance.Call_OnEatNCookies(EconomyMan.Instance.CookiesThisGame);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Cookie))
        {
            EatCookie(other.gameObject.GetComponent<Cookie>());
            return;
        }

        if (other.CompareTag(Tags.ImprovedCookie))
        {
            EatImprovedCookie(other.gameObject.GetComponent<ImprovedCookie>());
            return;
        }
        
    }
}
