using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamodsSerializable : IIntSerializable
{
    public void Save(int _amount)
    {
        DataMan.Instance.userData.Diamonds = _amount;
    }

    public int GetValue()
    {
        return DataMan.Instance.userData.Diamonds;
    }

}
