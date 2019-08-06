using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Account
{
    public Money money;
    public Money thisGame;
    public IIntSerializable saveable;
    public IReporteable reporteable;
    bool shouldReport = false;

    public Account(Currency _currency, IIntSerializable _saveable, IReporteable _reportable=null)
    {
        this.saveable = _saveable;
        this.money = new Money(this.saveable.GetValue() , _currency);
        this.thisGame = new Money(0, _currency);
        if (_reportable != null)
        {
            this.reporteable = _reportable;
            this.shouldReport = true;
        }
    }

    public bool SubstractIfIHaveFunds(Money other)
    {
        if (money.CompareTo(other) != -1)
        {
            Substract(other);
            return true;
        }

        return false;
    }

    public bool CanSubstractIfIHaveFunds(Money other)
    {
        if (money.CompareTo(other) != -1)
        {
            return CanSubstract(other);
        }
        return false;
    }



    public void Substract(Money other)
    {
        money.Substract(other);
        ChangeValue();
    }

    public bool CanSubstract(Money other)
    {
        return money.CanSubstract(other);
    }


    public void Add(Money other)
    {
        money.Add(other);
        ChangeValue();
    }

    public void Add(int amount)
    {
        money.Add(amount);
        ChangeValue();
    }

    void ChangeValue()
    {
        this.saveable.Save(money.amount);
        if (shouldReport)
            reporteable.Report();
    }

    public void EmptyFounds()
    {
        money.amount = 0;
        thisGame.amount = 0;
    }
}
