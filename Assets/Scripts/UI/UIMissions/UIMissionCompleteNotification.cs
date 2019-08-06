using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMissionCompleteNotification : UINotification
{
    public GameObject missionText;

    public void Show(string _text)
    {
        this.missionText.GetComponent<Text>().text = _text;
        base.Show();
    }
}
