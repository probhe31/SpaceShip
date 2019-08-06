
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UIDailyRewardScreen : UIScreen
{
    
    //public DailyRewardSystem dailyRewardSystem;
    public List<UIDailyRewardBox> boxes;
    public UIHUDEconomy hudEconomy;
    public DailyRewardx2Btn dailyRewardx2Btn;

    public GameObject claimBtn;
    public GameObject continueBtn;

    private void Start()
    {
        OnEnter();
        claimBtn.SetActive(true);
        continueBtn.SetActive(false);
    }

    public void GenerateGift()
    {

    }

    public void OnClickDailyRewardx2Btn()
    {
        continueBtn.SetActive(false);
        claimBtn.GetComponent<Button>().interactable = false;
    }

    public void OnClickClaimReward()
    {
        GetReward(1);
        claimBtn.SetActive(false);
        dailyRewardx2Btn.gameObject.SetActive(false);
        continueBtn.SetActive(true);
    }

    void GetReward(int factor)
    {
        Reward reward = RewardMan.Instance.dailyRewardSystem.ClaimReward(factor);
        //Debug.Log("GANASTE_ _ " +reward.amount + " " + reward.type);
        switch (reward.type)
        {
            case eReward.NONE:
                break;
            case eReward.COOKIE:
                EconomyMan.Instance.AddCookiesFromReward(reward.amount);
                hudEconomy.UpdateCookies();
                break;
            case eReward.SPECIAL_COOKIE:
                break;
            case eReward.DIAMOND:
                EconomyMan.Instance.AddDiamondsFromReward(reward.amount);
                hudEconomy.UpdateDiamonds();
                break;
            case eReward.BOX:
                break;
            default:
                break;
        }

        if (reward.type != eReward.NONE)
        {
            EventsMan.Instance.Call_OnCollectDailyReward();
        }
    }

    public override void OnExit()
    {
        ScreenMan.Instance.OpenScene(Screens.MainMenuScreen);
    }

    public override void OnEnter()
    {
        int rewardDay = DataMan.Instance.userData.CurrentRewardId;

        for (int i = 0; i < boxes.Count; i++)
        {
            if(i< rewardDay)
            {
                this.boxes[i].SetStateBox(RewardMan.Instance.dailyRewardSystem.rewards[i], UIDailyRewardBox.eRewardBoxState.CLAIMED,i);
            }
            else if (i == rewardDay)
            {
                this.boxes[i].SetStateBox(RewardMan.Instance.dailyRewardSystem.rewards[i], UIDailyRewardBox.eRewardBoxState.UNLOCKED,i);
            }
            else if (i > rewardDay)
            {
                this.boxes[i].SetStateBox(RewardMan.Instance.dailyRewardSystem.rewards[i], UIDailyRewardBox.eRewardBoxState.LOCKED,i);
            }
        }

        dailyRewardx2Btn.Initialize(this, OnFailWatchVideo, OnCompleteWatchVideo);
        
    }

    void OnCompleteWatchVideo()
    {
        GetReward(2);
        claimBtn.SetActive(false);
        continueBtn.SetActive(true);
        dailyRewardx2Btn.gameObject.SetActive(false);
    }


    void OnFailWatchVideo()
    {
        claimBtn.SetActive(true);
        continueBtn.SetActive(false);
        dailyRewardx2Btn.gameObject.SetActive(true);
        claimBtn.GetComponent<Button>().interactable = true;

    }

    public void OnClickGoToMainMenuBtn()
    {
        ScreenMan.Instance.OpenScene(Screens.MainMenuScreen);
    }



}
