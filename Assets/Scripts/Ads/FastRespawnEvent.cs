using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class FastRespawnEvent : IUnityAdsListener
{
    OnUnityAdsReadyBtn ready;
    public string myPlacementId = "resurrection_chimney";


    public void SetListener(OnUnityAdsReadyBtn c)
    {
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
        this.ready ? .Invoke(placementId);
    }

    void IUnityAdsListener.OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == myPlacementId)
        {
            if (showResult == ShowResult.Finished)
            {
                Game.Instance.RespawnPlayer();
            }
            else if (showResult == ShowResult.Skipped)
            {
            }
            else if (showResult == ShowResult.Failed)
            {
                Debug.LogWarning("The ad did not finish due to an error.");
            }

        }

    }
}
