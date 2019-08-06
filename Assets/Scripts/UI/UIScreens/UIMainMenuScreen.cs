using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIMainMenuScreen : UIScreen
{
    public GameObject dailyRewardButton;
    public EventTrigger playBtn;
    public EventTrigger achievementBtn;

    private void Start()
    {
        EventTrigger.Entry entryPlay = new EventTrigger.Entry();
        entryPlay.eventID = EventTriggerType.PointerClick;
        entryPlay.callback.AddListener((data) => { OnClickPlayBtn((PointerEventData)data); });
        playBtn.triggers.Add(entryPlay);

        EventTrigger.Entry entryAchievement = new EventTrigger.Entry();
        entryAchievement.eventID = EventTriggerType.PointerClick;
        entryAchievement.callback.AddListener((data) => { OnClickAchievementButton((PointerEventData)data); });
        achievementBtn.triggers.Add(entryAchievement);

        GooglePlayMan.Instance.Login();

        OnEnter();
    }

    void OnClickPlayBtn(PointerEventData data)
    {
        ScreenMan.Instance.OpenScene(Screens.GameScreen);
    }

    public void OnClickAchievementButton(PointerEventData data)
    {
        ScreenMan.Instance.OpenScene(Screens.AchievementScreen);
    }

    public override void OnEnter()
    {
        RewardMan.Instance.dailyRewardSystem.Analize();
        this.dailyRewardButton.SetActive(RewardMan.Instance.dailyRewardSystem.HasReward());

    }

    public override void OnExit()
    {
    }


    public void OnClickDailyReward()
    {
        ScreenMan.Instance.OpenScene(Screens.DailyRewardScreen);
    }

    public void OnClickLot()
    {
        ScreenMan.Instance.OpenScene(Screens.LotPostGameScreen);
    }

    public UIPostGameMissionsPopup missionPopup;

    public void OnClickMissions()
    {
        missionPopup.Open(Screens.MainMenuScreen);
    }

    

    
    /*public void TestAchievement(GameObject bola)
    {
        GooglePlayMan.Instance.UpdateAchievement(bola);
    }*/

    public void LoginGooglePlay()
    {
        GooglePlayMan.Instance.Login();
    }
}
