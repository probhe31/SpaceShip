using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICreditsScreen : UIScreen
{
    public override void OnEnter()
    {
    }

    public override void OnExit()
    {
    }

    public void OnClickGoToMainMenuBtn()
    {
        ScreenMan.Instance.OpenScene(Screens.MainMenuScreen);
    }

    public void OnClickGoToOptionsBtn()
    {
        ScreenMan.Instance.OpenScene(Screens.OptionsScreen);
    }
}
