using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionData : ISaveable
{
    ValueKey<int> _id_mission;
    ValueKey<bool> _complete;


    public MissionData(int indexMission)
    {
        _id_mission = new ValueKey<int>("_idMission_" + indexMission, -1);
        _complete = new ValueKey<bool>("_idMission_c" + indexMission, false);

    }

    public int IdMission
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _id_mission);
            return _id_mission.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _id_mission);
        }
    }

    public bool IsMissionComplete
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _complete);
            return _complete.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _complete);
        }
    }

    public void LoadData()
    {
        PlayerPrefUtils.LoadValue(ref _id_mission);
        PlayerPrefUtils.LoadValue(ref _complete);

    }

    public void SetDefaults()
    {
        PlayerPrefUtils.SetDefaultValue(ref _id_mission);
        PlayerPrefUtils.SetDefaultValue(ref _complete);
    }


}
