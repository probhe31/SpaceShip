using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretButtonData : ISaveable
{
    ValueKey<bool> _found;


    public SecretButtonData(int idSecret)
    {
        _found = new ValueKey<bool>("_found" + idSecret, false);
    }


    public bool WasFound
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _found);
            return _found.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _found);
        }
    }


    public void LoadData()
    {
        PlayerPrefUtils.LoadValue(ref _found);
    }

    public void SetDefaults()
    {
        PlayerPrefUtils.SetDefaultValue(ref _found);
    }
}
