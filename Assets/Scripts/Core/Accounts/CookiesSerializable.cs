using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookiesSerializable : IIntSerializable
{
    public void Save(int _amount)
    {
        DataMan.Instance.userData.Cookies = _amount;
    }

    public int GetValue()
    {
        return DataMan.Instance.userData.Cookies;
    }

}
