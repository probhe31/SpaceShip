using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public delegate void OnSuccessCompleteVideo();
public delegate void OnFailCompleteVideo();

public delegate void OnUnityAdsReadyBtn(string placement);


[RequireComponent(typeof(Button))]
public class FastRespawnBtn : MonoBehaviour
{

    Button myButton;
    public string myPlacementId = "resurrection_chimney";
    UIBuyLifePopup uIBuyLifePopup;

    public void Initialize(UIBuyLifePopup _uIBuyLifePopup)
    {
        this.uIBuyLifePopup = _uIBuyLifePopup;
        myButton = GetComponent<Button>();
        myButton.interactable = Advertisement.IsReady(myPlacementId);
        if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);

        AdsMan.Instance.fastRespawnEvent.SetListener(OnUnityAdsReady);
    }

    void ShowRewardedVideo()
    {
        this.uIBuyLifePopup.Close();
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
