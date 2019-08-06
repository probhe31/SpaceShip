using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGiftGameMissionPopup : UIPopup
{

    public Button openGiftBtn;
    public Button continueBtn;

    protected override void OnClose()
    {
        ScreenMan.Instance.OpenScene(Screens.GameOverScreen);
    }

    protected override void OnOpen()
    {
        openGiftBtn.gameObject.SetActive(true);
        continueBtn.gameObject.SetActive(false);
    }

    public void OnClickOpenGift()
    {
        if (MissionMan.Instance.AllMissionWasComplete())
        {
            openGiftBtn.gameObject.SetActive(false);
            continueBtn.gameObject.SetActive(true);

            Debug.Log("deberia de abrir el regalo");
            MissionMan.Instance.ClaimReward();
        }
    }
}
