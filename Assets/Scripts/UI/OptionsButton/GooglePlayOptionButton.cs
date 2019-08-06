using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooglePlayOptionButton : OptionButton, ILoadableData
{
    public void LoadData()
    {
        Debug.Log("loading google play configuration");
    }

    public override void OnClick()
    {
    }
}