using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour
{
    public HudText cookies;
    public HudText score;

    public void SetCookies(int _cookies)
    {
        cookies.SetText("" + _cookies);
    }

    public void UpdateCookies()
    {
        cookies.SetText("" + EconomyMan.Instance.Cookies);
    }
}
