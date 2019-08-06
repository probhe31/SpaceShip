using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsMan : MonoBehaviour
{
    public static EventsMan Instance;
    private void Awake()
    {
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    #region Diamonds events
    public delegate void ChangeDiamonds();
    public static event ChangeDiamonds OnChangeDiamonds;

    public void Call_OnChangeDiamonds()
    {
        OnChangeDiamonds?.Invoke();
    }
    #endregion

    #region Upgrades events

    public delegate void BuyUpgradeN(int idUpgrade);
    public static event BuyUpgradeN OnBuyUpgradeN;


    public void Call_OnBuyUpgrade(int idUpgrade)
    {
        OnBuyUpgradeN?.Invoke(idUpgrade);
    }

    #endregion

    #region Meters events

    public delegate void FallNMeters(int meters);
    public static event FallNMeters OnFallNMeters;

    public void Call_OnFallNMeters(int meters)
    {
        OnFallNMeters?.Invoke(meters);
    }

    #endregion

    #region Itch Meters events

    public delegate void TouchWallNMeters(int meters);
    public static event TouchWallNMeters OnTouchWallNMeters;

    public void Call_OnTouchWallNMeters(int meters)
    {
        OnTouchWallNMeters?.Invoke(meters);
    }

    #endregion

    #region Cookies events


    public delegate void ChangeCookies();
    public static event ChangeCookies OnChangeCookies;

    public void Call_OnChangeCookies()
    {
        OnChangeCookies?.Invoke();
    }

    public delegate void EatNCookies(int cookies);
    public static event EatNCookies OnEatNCookies;


    public void Call_OnEatNCookies(int cookies)
    {
        OnEatNCookies?.Invoke(cookies);
    }

    #endregion

    #region Special cookies events


    public delegate void EatNSpecialCookies(int specialCookies);
    public static event EatNSpecialCookies OnEatNSpecialCookies;


    public void Call_OnEatNSpecialCookies(int specialCookies)
    {
        OnEatNSpecialCookies?.Invoke(specialCookies);
    }

    #endregion

    #region RedLigths events
    public delegate void TouchNRedLights(int redLights);
    public static event TouchNRedLights OnTouchNRedLights;

    public void Call_OnTouchNRedLights(int lights)
    {
        OnTouchNRedLights?.Invoke(lights);
    }
    #endregion

    #region New game events
    public delegate void NewGameEvent();
    public static event NewGameEvent OnNewGameStart;

   

    public void Call_OnNewGameStart()
    {
        OnNewGameStart?.Invoke();
    }

    #endregion

    #region Game over events
    public delegate void GameOverEvent();
    public static event GameOverEvent OnGameOver;

    public void Call_OnGameOver()
    {
        OnGameOver?.Invoke();
    }
    #endregion

    #region Complete daily reward events
    public delegate void CompleteDailyReward();
    public static event CompleteDailyReward OnCompleteDailyReward;

    public void Call_OnCompleteDailyReward()
    {
        OnCompleteDailyReward?.Invoke();
    }
    #endregion
    
    #region Collect daily reward events
    public delegate void CollectDailyReward();
    public static event CollectDailyReward OnCollectDailyReward;

    public void Call_OnCollectDailyReward()
    {
        OnCollectDailyReward?.Invoke();
    }
    #endregion

    #region SecretButtons

    public delegate void FoundSecretButton();
    public static event FoundSecretButton OnFoundSecretButton;


    public void Call_OnFoundSecretButton()
    {
        OnFoundSecretButton?.Invoke();
    }

    #endregion
}

