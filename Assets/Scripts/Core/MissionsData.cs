using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionsData : ISaveable
{
    ValueKey<bool> _hasMissions = new ValueKey<bool>("has_missions", false);
    public List<MissionData> missions;
    ValueKey<int> _missionMeterAcum = new ValueKey<int>("_misionMeterAcum", 0);
    ValueKey<int> _missionItchMeterAcum = new ValueKey<int>("_missionItchMeterAcum", 0);
    ValueKey<int> _missionCookieAcum = new ValueKey<int>("_misionCookieAcum", 0);
    ValueKey<int> _missionRedLightAcum = new ValueKey<int>("_missionRedLightAcum", 0);
    ValueKey<int> _missionEnterChimneyAcum = new ValueKey<int>("_missionEnterChimneyAcum", 0);

    ValueKey<int> _missionSpecialCookieAcum = new ValueKey<int>("_misionSpecialCookieAcum", 0);





    public MissionsData(){

        this.missions = new List<MissionData>();
        for (int i = 0; i < Constants.num_missions_per_level; i++)
        {
            this.missions.Add(new MissionData(i));
        }

    }

    public int MissionItchMeterAcum
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _missionItchMeterAcum);
            return _missionItchMeterAcum.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _missionItchMeterAcum);
        }
    }


    public int MissionMeterAcum
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _missionMeterAcum);
            return _missionMeterAcum.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _missionMeterAcum);
        }
    }

    public int MissionEnterChimneyAcum
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _missionEnterChimneyAcum);
            return _missionEnterChimneyAcum.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _missionEnterChimneyAcum);
        }
    }



    public int MissionCookieAcum
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _missionCookieAcum);
            return _missionCookieAcum.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _missionCookieAcum);
        }
    }

    public int MissionRedLightAcum
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _missionRedLightAcum);
            return _missionRedLightAcum.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _missionRedLightAcum);
        }
    }


    public int MissionSpecialCookieAcum
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _missionSpecialCookieAcum);
            return _missionSpecialCookieAcum.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _missionSpecialCookieAcum);
        }
    }


    public bool HasMissions
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _hasMissions);
            return _hasMissions.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _hasMissions);
        }
    }

    public void LoadData()
    {
        PlayerPrefUtils.LoadValue(ref _hasMissions);
        for (int i = 0; i < Constants.num_missions_per_level; i++)
        {
            missions[i].LoadData();
        }
        PlayerPrefUtils.LoadValue(ref _missionCookieAcum);
        PlayerPrefUtils.LoadValue(ref _missionMeterAcum);
        PlayerPrefUtils.LoadValue(ref _missionSpecialCookieAcum);
        PlayerPrefUtils.LoadValue(ref _missionRedLightAcum);
        PlayerPrefUtils.LoadValue(ref _missionEnterChimneyAcum);
    }

    public void SetDefaults()
    {        
        PlayerPrefUtils.SetDefaultValue(ref _hasMissions);
        for (int i = 0; i < Constants.num_missions_per_level; i++)
        {
            missions[i].SetDefaults();
        }
        PlayerPrefUtils.SetDefaultValue(ref _missionCookieAcum);
        PlayerPrefUtils.SetDefaultValue(ref _missionMeterAcum);
        PlayerPrefUtils.SetDefaultValue(ref _missionSpecialCookieAcum);
        PlayerPrefUtils.SetDefaultValue(ref _missionRedLightAcum);
        PlayerPrefUtils.SetDefaultValue(ref _missionEnterChimneyAcum);

    }


}
