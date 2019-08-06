using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICarouselMissions : MonoBehaviour
{
    public Text missionTxt;
    public List<int> currentMissions = new List<int>();

    public void Show()
    {       
        this.cur = 0;

        for (int i = 0; i < MissionMan.Instance.currentMisions.Count; i++)
        {
            if (!MissionMan.Instance.GetMissionWithCurrentMissionsID(i).IsMissionComplete)
            {
                currentMissions.Add(MissionMan.Instance.currentMisions[i]);
            }
        }

        if (currentMissions.Count > 0)
        {
            missionTxt.text = MissionMan.Instance.GetMissionByID(currentMissions[cur]).GetString();
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }


    }


    float ctSlide;
    public float tSlide = 1.8f;
    int cur = 0;

    private void Update()
    {
        this.missionTxt.text = MissionMan.Instance.GetMissionByID(currentMissions[cur]).GetString();

        this.ctSlide += Time.deltaTime;
        if (this.ctSlide > this.tSlide)
        {
            this.ctSlide = 0;
            this.cur++;
            if (this.cur > currentMissions.Count-1)
                this.gameObject.SetActive(false);
        }

    }
}
