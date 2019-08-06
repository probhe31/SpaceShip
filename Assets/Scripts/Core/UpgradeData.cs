using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeData 
{
    ValueKey<int> _status;
    ValueKey<int> _level;


    public UpgradeData(int idUpgrade)
    {
        _status = new ValueKey<int>("_upgrade"+ idUpgrade, ItemState.Lock);
        _level = new ValueKey<int>("_upgrade_level" + idUpgrade, ItemState.Lock);
    }

    public int Status
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _status);
            return _status.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _status);
        }
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

    public void LoadData()
    {
        PlayerPrefUtils.LoadValue(ref _status);
        PlayerPrefUtils.LoadValue(ref _level);

    }

    public void SetDefaults()
    {
        PlayerPrefUtils.SetDefaultValue(ref _status);
        PlayerPrefUtils.SetDefaultValue(ref _level);
    }

}
