using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData
{

    ValueKey<int> _status;

    public CharacterData(int idUpgrade)
    {
        _status = new ValueKey<int>("_character" + idUpgrade, CharacterState.Unlock);
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

    public void LoadData()
    {
        PlayerPrefUtils.LoadValue(ref _status);
    }

    public void SetDefaults()
    {
        PlayerPrefUtils.SetDefaultValue(ref _status);
    }
}
