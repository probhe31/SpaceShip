using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementData : ISaveable
{
    ValueKey<int> _level;
    ValueKey<bool> _complete;
    ValueKey<bool> _collected;
    

    public AchievementData(int idAchievement)
    {
        _level = new ValueKey<int>("_level" + idAchievement, 0);
        _complete = new ValueKey<bool>("_complete" + idAchievement, false);
        _collected = new ValueKey<bool>("_collected" + idAchievement, false);

    }

    

    public int Level
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _level);
            return _level.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _level);
        }
    }

    public bool IsComplete
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

    public bool IsCollected
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _collected);
            return _collected.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _collected);
        }
    }

    public void LoadData()
    {
        PlayerPrefUtils.LoadValue(ref _level);
        PlayerPrefUtils.LoadValue(ref _complete);
        PlayerPrefUtils.LoadValue(ref _collected);
    }

    public void SetDefaults()
    {
        PlayerPrefUtils.SetDefaultValue(ref _level);
        PlayerPrefUtils.SetDefaultValue(ref _complete);
        PlayerPrefUtils.SetDefaultValue(ref _collected);
    }

}
