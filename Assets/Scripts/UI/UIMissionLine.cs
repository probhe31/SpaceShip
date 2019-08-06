using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMissionLine : MonoBehaviour
{
    public Text missionText;
    public Image lockImg;
    public Image completeImg;
    Mission mission;

    public void Fill(Mission _mission)
    {
        this.mission = _mission;

        this.missionText.text = this.mission.GetString() ;
        if (this.mission.IsMissionComplete)
        {
            this.completeImg.gameObject.SetActive(true);
            this.lockImg.gameObject.SetActive(false);
        }
        else
        {
            this.completeImg.gameObject.SetActive(false);
            this.lockImg.gameObject.SetActive(true);
        }
    }

    
}
