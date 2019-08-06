using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotCookie : BlockElement, IEateable, IMagneticeable
{
    float speedY = 0.5f;
    public GameObject boca;
    float angle = 0;
    float speed = (2 * Mathf.PI) / 0.5f;
    float radius = 0.2f;
    bool wasEat = false;

    public void OnEat()
    {
        this.wasEat = true;
        this.gameObject.SetActive(false);
    }


    public override void OnInitialize()
    {
        base.OnInitialize();
        this.boca.SetActive(false);
        this.transform.eulerAngles = new Vector3(-90, 45, 0);
        this.IsItMagnetizable();
        this.wasEat = false;


    }

    private void Update()
    {
        Vector3 newpos = this.transform.position;       
        angle += speed * Time.deltaTime;
        newpos.x = Mathf.Cos(angle) * radius;
        newpos.z = Mathf.Sin(angle) * radius;
        this.transform.position = newpos;

        if(Game.Instance.player && Game.Instance.player.transform.position.y - this.transform.position.y < 2)
        {
            boca.SetActive(true);
        }

    }


    public override void OnKill()
    {
        if (WasAtrackted() && !wasEat)
        {
            Game.Instance.player.lotCookieSensor.EatLotCookie(this);
        }

        if (UpgradesMan.Instance.HasMagneticLotEnable)
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
        if (UpgradesMan.Instance.HasMagneticLotEnable)
        {
            this.GetComponent<MagneticToPlayer>().Initialize();
        }
        else
        {
            this.GetComponent<MagneticToPlayer>().Remove();
        }
    }

}