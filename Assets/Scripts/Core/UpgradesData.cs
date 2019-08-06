using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//upgrade 0 lock  1 unlock  2 bought
public class UpgradesData : ISaveable
{
    public List<UpgradeData> upgrades;
    public List<SlotData> slots;
    ValueKey<int> _last_updated_slot = new ValueKey<int>("_last_updated_slot", 0);

    public UpgradesData()
    {
        this.slots = new List<SlotData>();
        this.upgrades = new List<UpgradeData>();

        for (int i = 0; i < Constants.num_upgrades; i++)
        {
            upgrades.Add(new UpgradeData(i));
        }

        for (int i = 0; i < Constants.num_upgrade_slots; i++)
        {
            slots.Add(new SlotData(i));
        }
    }

    public int LastUpdateSlot
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _last_updated_slot);
            return _last_updated_slot.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _last_updated_slot);
        }
    }

   

    public void LoadData()
    {
        PlayerPrefUtils.LoadValue(ref _last_updated_slot);
        
        for (int i = 0; i < Constants.num_upgrades; i++)
        {
            upgrades[i].LoadData();
        }

        for (int i = 0; i < Constants.num_upgrade_slots; i++)
        {
            slots[i].LoadData();
        }
    }

    public void SetDefaults()
    {
        PlayerPrefUtils.SetDefaultValue(ref _last_updated_slot);

        for (int i = 0; i < Constants.num_upgrades; i++)
        {
            upgrades[i].SetDefaults();
        }

        for (int i = 0; i < Constants.num_upgrade_slots; i++)
        {
            slots[i].SetDefaults();
        }
    }
}
