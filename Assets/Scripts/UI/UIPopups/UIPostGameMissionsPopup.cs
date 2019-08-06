using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPostGameMissionsPopup : UIPopup
{
    public MissionList missionList;
    string from = "";

    public void Open(string _from)
    {
        this.from = _from;
        base.Open();
    }

    protected override void OnClose()
    {
        if (MissionMan.Instance.AllMissionWasComplete())
        {
            UIMan.Instance.OpenGiftMissionPopup();
        }
        else
        {
            if (this.from != Screens.MainMenuScreen)
            { 
                ScreenMan.Instance.OpenScene(Screens.GameOverScreen);
            }
        }
    }

    protected override void OnOpen()
    {   
        missionList.LoadMissions();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Close();
        }
    }

    /*public void OnClickOpenGift()
    {
        if (MissionMan.Instance.AllMissionWasComplete())
        {
            Debug.Log("deberia de abrir el regalo");
            MissionMan.Instance.ClaimReward();
        }
    }*/
}
