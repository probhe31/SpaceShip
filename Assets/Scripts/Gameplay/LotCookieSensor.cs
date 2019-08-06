using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotCookieSensor : MonoBehaviour
{
    EconomyMan economyMan;
    List<int> reportOnLotCookies = new List<int>();

    private void Start()
    {
        this.economyMan = EconomyMan.Instance;
    }

    public void ReportOnLotCookies(int _reportOn)
    {
        this.reportOnLotCookies.Add(_reportOn);
    }

    public void EatLotCookie(LotCookie lotCookie)
    {
        this.economyMan.AddLotCookiesFromFalling(1);
        lotCookie.OnEat();
        GameObject p = TrashMan.spawn("eat_loot_cookie", this.transform.position);
        p.transform.eulerAngles = new Vector3(-90, 0, 0);
        p.GetComponent<ParticleSystem>().Play();

        for (int i = 0; i < reportOnLotCookies.Count; i++)
        {
            if (this.reportOnLotCookies[i] == EconomyMan.Instance.LotCookiesThisGame)
            {
                this.reportOnLotCookies.RemoveAt(i);
                EventsMan.Instance.Call_OnEatNSpecialCookies(EconomyMan.Instance.LotCookiesThisGame);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.LotCookie))
        {
            EatLotCookie(other.gameObject.GetComponent<LotCookie>());
            return;
        }
    }
}
