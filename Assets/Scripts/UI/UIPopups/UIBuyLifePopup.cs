using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void OnCloseBuyLifePopup(bool respawn);

public class UIBuyLifePopup : UIPopup
{
    float c_timeToClose;
    float timeToClose = 2.5f;
    bool waiting = false;
    float percent = 0;
    public Image clock;
    public FastRespawnBtn fastRespawnBtn;
    OnCloseBuyLifePopup callback_OnCloseBuyLifePopup;

    public void Open(OnCloseBuyLifePopup _onCloseBuyLife)
    {
        this.callback_OnCloseBuyLifePopup = _onCloseBuyLife;
        StartClock();
        fastRespawnBtn.Initialize(this);
        base.Open();
    }


    public void StartClock()
    {
        Debug.Log("calling start clock again");
        this.waiting = true;
        this.c_timeToClose = timeToClose;
    }


    private void Update()
    {
        if (!this.waiting)
            return;

        this.c_timeToClose -= Time.deltaTime;

        this.percent = Mathf.Clamp(this.c_timeToClose / timeToClose, 0, 1);
        this.clock.fillAmount = 1-this.percent;


        if (this.c_timeToClose <= 0)
        {
            this.waiting = false;
            this.c_timeToClose = 0;
            Close(false);
        }
    }

    public void StopWaiting()
    {
        this.waiting = false;
    }

    protected override void OnClose()
    {

    }

    
    protected override void OnOpen()
    {
        //fastRespawnBtn.Initialize(this, FailWatchVideo, SuccessfullWathVideo);
        //fastRespawnBtn.Initialize(this);
    }


    public void Close(bool respawn)
    {
        callback_OnCloseBuyLifePopup?.Invoke(respawn);
        base.Close();
    }


    /*void SuccessfullWathVideo()
    {
        waiting = false;
        
        Close(true);
    }


    void FailWatchVideo()
    {
        Close(false);
    }*/


    public void BuyHeart()
    {
        this.waiting = false;

        if (EconomyMan.Instance.Buy(new Money(Constants.price_respawn, Currency.COOKIE)))
        {
            Debug.Log("buy ");
            Game.Instance.uiGameScreen.hud.UpdateCookies();
            Game.Instance.RespawnPlayer();
            Close(true);
        }
        else
        {
            Debug.Log("no buy ");

            Close(false);
        }
    }


    public void WatchVideo()
    {
        Debug.Log("desea mirar un video para seguir jugando");
        waiting = false;
    }
}
