using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionList : MonoBehaviour
{
    public List<UIMissionLine> missionLines;

    public void LoadMissions()
    {
        for (int i = 0; i < MissionMan.Instance.currentMisions.Count; i++)
        {
            missionLines[i].Fill(MissionMan.Instance.GetMissionWithCurrentMissionsID(i));
        }
    }

}
