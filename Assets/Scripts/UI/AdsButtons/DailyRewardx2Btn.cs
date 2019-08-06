using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

[RequireComponent(typeof(Button))]
public class DailyRewardx2Btn : MonoBehaviour
{
    Button myButton;
    public string myPlacementId = "dailyRewardx2";
    UIDailyRewardScreen uIDailyRewardScreen;

    public void Initialize(UIDailyRewardScreen _uIDailyRewardScreen, OnFailCompleteVideo _onFail, OnSuccessCompleteVideo _onComplete)
    {
        this.uIDailyRewardScreen = _uIDailyRewardScreen;
        myButton = GetComponent<Button>();
        myButton.interactable = Advertisement.IsReady(myPlacementId);
        if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);
        AdsMan.Instance.dailyRewardx2Event.SetListener(OnUnityAdsReady, _onFail, _onComplete);
    }

    void ShowRewardedVideo()
    {
        uIDailyRewardScreen.OnClickDailyRewardx2Btn();
        Advertisement.Show(myPlacementId);
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == myPlacementId)
        {
            myButton.interactable = true;
        }
    }

}
