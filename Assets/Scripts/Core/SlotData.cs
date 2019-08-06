using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotData
{
    ValueKey<int> _slot_upgrade;


    public SlotData(int idUpgrade)
    {
        _slot_upgrade = new ValueKey<int>("_slot_upgrade_" + idUpgrade, (int)eUpgrade.NONE);
    }

    public int SlotUpgrade
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _slot_upgrade);
            return _slot_upgrade.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _slot_upgrade);
        }
    }

    public void LoadData()
    {
        PlayerPrefUtils.LoadValue(ref _slot_upgrade);
    }

    public void SetDefaults()
    {
        PlayerPrefUtils.SetDefaultValue(ref _slot_upgrade);
    }
}
