using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOverScreen : UIScreen
{

    public HudText bestScoreText;
    public HudText scoreText;
    //public HudText cookiesText;

    private void Start()
    {
        OnEnter();
    }

    public override void OnEnter()
    {
        bestScoreText.SetText(""+DataMan.Instance.userData.BestScore);
        scoreText.SetText("" + DataMan.Instance.userData.LastScore);
        //cookiesText.SetText("" + DataMan.Instance.userData.Cookies);
    }

    public override void OnExit()
    {
    }

    public void OnClickGoToMainMenuBtn()
    {
        ScreenMan.Instance.OpenScene(Screens.MainMenuScreen);
    }

    public void OnClickStoreBtn()
    {
        ScreenMan.Instance.OpenScene(Screens.StoreScreen);
    }

    public void OnClickRetryBtn()
    {
        ScreenMan.Instance.OpenScene(Screens.GameScreen);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnClickRetryBtn();
        }
    }

    
}
