using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class DailyRewardx2Event : IUnityAdsListener
{
    OnFailCompleteVideo onFail;
    OnSuccessCompleteVideo onComplete;
    OnUnityAdsReadyBtn ready;
    public string myPlacementId = "dailyRewardx2";

    public void SetListener(OnUnityAdsReadyBtn c, OnFailCompleteVideo _onFail, OnSuccessCompleteVideo _onComplete)
    {
        this.onFail = _onFail;
        this.onComplete = _onComplete;
        this.ready = c;
    }

    public void OnUnityAdsDidError(string message)
    {

    }

    public void OnUnityAdsDidStart(string placementId)
    {
    }

    public void OnUnityAdsReady(string placementId)
    {
        this.ready?.Invoke(placementId);
    }

    void IUnityAdsListener.OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == myPlacementId)
        {
            if (showResult == ShowResult.Finished)
            {
                this.onComplete?.Invoke();
            }
            else if (showResult == ShowResult.Skipped)
            {
                this.onFail?.Invoke();
            }
            else if (showResult == ShowResult.Failed)
            {
                this.onFail?.Invoke();

                Debug.LogWarning("The ad did not finish due to an error.");
            }
        }

        
    }
}
