using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAchievementButton : MonoBehaviour
{
    public GameObject notification;

    private void Start()
    {
        notification.SetActive(AchievementMan.Instance.IsThereAnyPendingToCollect());
    }
}
