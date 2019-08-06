using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eHOW
{
    FALLING,
    REWARD
}

public class EconomyMan : MonoBehaviour
{
    Account cookiesAccount;
    Account diamondsAccount;
    Account lotCookiesAccount;

    public int Cookies
    {
        get
        {
            return cookiesAccount.money.amount;
        }
    }

    public int Diamonds
    {
        get
        {
            return diamondsAccount.money.amount;
        }
    }

    public int CookiesThisGame
    {
        get
        {
            return cookiesAccount.thisGame.amount;
        }
    }

    public int LotCookiesThisGame
    {
        get
        {
            return lotCookiesAccount.thisGame.amount;
        }
    }

    public int LotCookies
    {
        get
        {
            return lotCookiesAccount.money.amount;
        }   
    }

    public static EconomyMan Instance;

    private void Awake()
    {
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

   
    private void Start()
    {
        cookiesAccount = new Account(Currency.COOKIE, new CookiesSerializable(), new CookiesChangeReport());
        diamondsAccount = new Account(Currency.DIAMOND, new DiamodsSerializable(), new DiamondsChangeReport());
        lotCookiesAccount = new Account(Currency.LOT_COOKIE, new LotCookiesSerializable());
        EventsMan.OnNewGameStart += OnNewGameStart;
    }

    public void AddCookiesFromFalling(int amount)
    {
        this.cookiesAccount.Add(amount);
        this.cookiesAccount.thisGame.Add(amount);
    }

    public void AddCookiesFromReward(int amount)
    {
        this.cookiesAccount.Add(amount);
    }

    public void AddDiamondsFromReward(int amount)
    {
        this.diamondsAccount.Add(amount);
    }

    void OnNewGameStart()
    {
        this.cookiesAccount.thisGame = new Money(0, Currency.COOKIE);
        this.lotCookiesAccount.thisGame = new Money(0, Currency.LOT_COOKIE);
    }

    private void OnDestroy()
    {
        EventsMan.OnNewGameStart -= OnNewGameStart;
    }

    public void AddLotCookiesFromFalling(int amount)
    {
        this.lotCookiesAccount.Add(amount);
        this.lotCookiesAccount.thisGame.Add(amount);
    }

    public void Add(Money reward)
    {
        switch (reward.currency)
        {
            case Currency.COOKIE:
                AddCookiesFromReward(reward.amount);
                break;
            case Currency.DIAMOND:
                AddDiamondsFromReward(reward.amount);
                break;
        }
    }


    public bool CanBuy(Money price)
    {
        bool res = false;
        switch (price.currency)
        {
            case Currency.COOKIE:
                res = cookiesAccount.CanSubstractIfIHaveFunds(price);
                break;
            case Currency.DIAMOND:
                res = diamondsAccount.CanSubstractIfIHaveFunds(price);
                break;
        }

        return res;
    }


    public bool Buy(Money price)
    {
        bool res = false;
        switch (price.currency)
        {
            case Currency.COOKIE:
                res = cookiesAccount.SubstractIfIHaveFunds(price);
                break;
            case Currency.DIAMOND:
                res = diamondsAccount.SubstractIfIHaveFunds(price);
                break;
        }

        return res;
    }

    public void EmptyFunds()
    {
        this.cookiesAccount.EmptyFounds();
        this.lotCookiesAccount.EmptyFounds();
        this.diamondsAccount.EmptyFounds();
    }
}
