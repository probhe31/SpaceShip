using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIHUDEconomy : MonoBehaviour
{
    public HudText cookies_text;
    public HudText diamonds_text;


    private void Start()
    {
        LoadValues();
        EventsMan.OnChangeCookies += UpdateCookies;
        EventsMan.OnChangeDiamonds += UpdateDiamonds;
    }


    private void OnDestroy()
    {
        EventsMan.OnChangeCookies -= UpdateCookies;
        EventsMan.OnChangeDiamonds -= UpdateDiamonds;
    }


    public void LoadValues()
    {
        UpdateCookies();
        UpdateDiamonds();        
    }

    public void UpdateCookies()
    {
        if(cookies_text)
            cookies_text.SetText("" + EconomyMan.Instance.Cookies);
    }

    public void UpdateDiamonds()
    {
        if(diamonds_text)
            diamonds_text.SetText("" + EconomyMan.Instance.Diamonds);
    }
    

}
