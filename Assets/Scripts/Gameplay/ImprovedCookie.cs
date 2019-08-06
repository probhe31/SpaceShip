using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovedCookie : BlockElement, IEateable, IMagneticeable
{
    bool wasEat = false;

    public override void OnInitialize()
    {
        base.OnInitialize();
        this.transform.eulerAngles = new Vector3(-90, 45, 0);
        this.GetComponent<Eyes>().Initialize();
        this.IsItMagnetizable();
        this.wasEat = false;

    }

    public void OnEat()
    {
        this.wasEat = true;
        this.gameObject.SetActive(false);
    }


    public override void OnKill()
    {
        if (WasAtrackted() && !wasEat)
        {
            Game.Instance.player.cookieSensor.EatImprovedCookie(this);
        }

        if (UpgradesMan.Instance.HasMagneticCookiesEnable)
        {
            this.GetComponent<MagneticToPlayer>().Remove();
        }


        base.OnKill();

    }

    public bool WasAtrackted()
    {
        return this.GetComponent<MagneticToPlayer>().IsAtrracted;
    }


    public void IsItMagnetizable()
    {
        if (UpgradesMan.Instance.HasMagneticCookiesEnable)
        {
            this.GetComponent<MagneticToPlayer>().Initialize();
        }
        else
        {
            this.GetComponent<MagneticToPlayer>().Remove();
        }
    }
}
