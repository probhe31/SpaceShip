using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackCookies : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            EconomyMan.Instance.AddCookiesFromReward(10);
        }    
    }
}
