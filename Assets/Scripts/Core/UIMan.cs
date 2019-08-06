using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMan : MonoBehaviour
{
    public static UIMan Instance;
    public Canvas canvas;
    private void Awake()
    {
        Instance = this;
        GameObject.DontDestroyOnLoad(this);
    }

    public void OpenGiftMissionPopup()
    {
        UIGiftGameMissionPopup uiGiftGameMissionPopup = GameObject.Instantiate(PoolMan.Instance.uiMissionGiftPopupPrefab).GetComponent<UIGiftGameMissionPopup>();
        uiGiftGameMissionPopup.transform.SetParent(this.canvas.transform);
        uiGiftGameMissionPopup.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        uiGiftGameMissionPopup.GetComponent<RectTransform>().localScale = Vector3.one;
        uiGiftGameMissionPopup.Open();
    }

}
