using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOptionsScreen : UIScreen
{
    public List<GameObject> loadablesOptionButtons;
    private void Start()
    {
        OnEnter();
    }

    public override void OnEnter()
    {
        for (int i = 0; i < loadablesOptionButtons.Count; i++)
        {
            loadablesOptionButtons[i].GetComponent<ILoadableData>().LoadData();
        }
    }

    public override void OnExit()
    {
    }

    public void OnClickGoToMainMenuBtn()
    {
        ScreenMan.Instance.OpenScene(Screens.MainMenuScreen);
    }


    public void OnClickResetBtn()
    {
        DataMan.Instance.ClearAll();
        Application.Quit();
        //EconomyMan.Instance.EmptyFunds();
    }
}
