using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsOptionButton : OptionButton
{
    public override void OnClick()
    {
        ScreenMan.Instance.OpenScene(Screens.CreditsScreen);
    }
}