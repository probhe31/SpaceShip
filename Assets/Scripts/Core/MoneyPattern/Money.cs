using UnityEngine.Assertions;

[System.Serializable]
public class Money 
{
    /*public int cookies;
    public int diamonds;

    public Money(int _cookies, int _diamonds)
    {
        this.cookies = _cookies;
        this.diamonds = _diamonds;
    }*/

    public Currency currency;
    public int amount;


    public Money(int _amount, Currency _currency)
    {
        this.amount = _amount;
        this.currency = _currency;
    }

    public Money(int _ammount)
    {
        this.amount = _ammount;
    }

   
    public void  AssertSameCurrencyAs(Money other)
    {
        Assert.AreEqual(currency, other.currency);
    }

    public int CompareTo(Money other)
    {
        AssertSameCurrencyAs(other);
        if (amount < other.amount) return -1;
        else if (amount == other.amount) return 0;
        else return 1;

    }

    public bool IsLessOrEqualThan(Money other)
    {
        AssertSameCurrencyAs(other);
        return amount<=other.amount;

    }

    public void Substract(Money other)
    {
        this.amount -= other.amount;
    }

    public bool CanSubstract(Money other)
    {
        return other.amount <= this.amount;
    }

    public void Add(Money other)
    {
        this.amount += other.amount;
    }

    public void Add(int _amount)
    {
        this.amount += _amount;
    }

    public override string ToString()
    {
        return "" + amount + " " + currency;
    }
}




