using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accumulator
{
    protected int amount;
    protected int amountThisGame;
    IIntSerializable serialize;

    public Accumulator(IIntSerializable _serialize)
    {
        this.amount = _serialize.GetValue();
        this.serialize = _serialize;
    }

    public int Amount
    {
        get
        {
            return amount;
        }
    }

    public int AmountThisGame
    {
        get
        {
            return amountThisGame;
        }
        set
        {
            amountThisGame = value;
        }
    }

    public void Add(int _amount)
    {
        amount += _amount;
        amountThisGame += _amount;
        this.serialize.Save(amount);

    }
}
