using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPausePopup : UIPopup
{

    public MissionList missionList;
    public MusicOptionButton musicOption;
    public SoundsOptionButton soundOption;

    protected override void OnClose()
    {
        Time.timeScale = 1;
    }

    protected override void OnOpen()
    {
        Time.timeScale = 0;
        missionList.LoadMissions();
        musicOption.LoadData();
        soundOption.LoadData();
    }

    public void OnClickContinue()
    {
        Close();
    }

    public void OnClickRetry()
    {
        ScreenMan.Instance.OpenScene(Screens.GameScreen);
        Close();
    }

    public void OnClickExit()
    {
        ScreenMan.Instance.OpenScene(Screens.MainMenuScreen);
        Close();
    }

    public UIAdjustParameters adjustParameters; 

    public void OpenParameters()
    {
        adjustParameters.Open();

    }

    private void Update()
    {
        if (Game.Instance.isGameOver)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
        }
    }
    
}
