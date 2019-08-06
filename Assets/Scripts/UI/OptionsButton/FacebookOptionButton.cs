using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacebookOptionButton : OptionButton, ILoadableData
{
    public void LoadData()
    {
        Debug.Log("loading facebook configuration");

    }

    public override void OnClick()
    {
    }
}