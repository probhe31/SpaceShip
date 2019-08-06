using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesMan : MonoBehaviour
{
    public GameUpgrades gameUpgrades;
    public static UpgradesMan Instance;
    public const int numUpgradesSlots = 2;
 

    public float ProbabilityMagneticCookies
    {
        get
        {
            return probabilityMagneticCookies;
        }
    }

    private void Awake()
    {
        Instance = this;
        LoadUpgradesData();
        EventsMan.OnNewGameStart += OnNewGameStart;
        GameObject.DontDestroyOnLoad(this.gameObject);


    }

    public List<eUpgrade> slots = new List<eUpgrade>() { eUpgrade.NONE, eUpgrade.NONE};
    bool hasMagneticLotCookiesEnable;
    bool hasMagneticCookiesEnable;
    bool hasImprovedCookiesEnable;
    bool hasRuinLaserEnable;
    bool hasBombEnable;
    float probabilityMagneticCookies;
    public GameObject bombBtnPrefab;

    public void OnNewGameStart()
    {
        for (int i = 0; i < Constants.num_upgrade_slots; i++)
        {
            //Debug.Log("slot " + DataMan.Instance.upgradesData.slots[i].SlotUpgrade);
            if (DataMan.Instance.upgradesData.slots[i].SlotUpgrade == (int)eUpgrade.COOKIES_IMAN)
            {
                this.hasMagneticCookiesEnable = true;
                MagneticUpgrade magnetic = Game.Instance.player.gameObject.AddComponent<MagneticUpgrade>();
                magnetic.Initialize();
                probabilityMagneticCookies = magnetic.GetProbabilityMagnetic();
            }

            if (DataMan.Instance.upgradesData.slots[i].SlotUpgrade == (int)eUpgrade.SPECIAL_COOKIES_IMAN)
            {
                this.hasMagneticLotCookiesEnable = true;
            }

            if (DataMan.Instance.upgradesData.slots[i].SlotUpgrade == (int)eUpgrade.IMPROVED_COOKIES)
            {
                this.hasImprovedCookiesEnable = true;
            }

            if (DataMan.Instance.upgradesData.slots[i].SlotUpgrade == (int)eUpgrade.RUIN_LASERS)
            {
                this.hasRuinLaserEnable = true;
            }

            if (DataMan.Instance.upgradesData.slots[i].SlotUpgrade == (int)eUpgrade.BOMB)
            {
                this.hasBombEnable = true;
                GameObject bombButton = GameObject.Instantiate(bombBtnPrefab);
                bombButton.transform.parent = Game.Instance.uiGameScreen.containerUpgrades.transform;

                DropBombUpgrade drop = Game.Instance.player.gameObject.AddComponent<DropBombUpgrade>();
                drop.Initialize(bombButton);

            }
        }

    }
    
    
    public bool HasRuinLasersEnable
    {
        get
        {
            return hasRuinLaserEnable;
        }
    }

    public bool HasImprovedCookiesEnable
    {
        get
        {
            return hasImprovedCookiesEnable;
        }
    }

    public bool HasMagneticCookiesEnable
    {
        get
        {
            return hasMagneticCookiesEnable;
        }
    }

    public bool HasMagneticLotEnable
{
        get
        {
            return hasMagneticLotCookiesEnable;
        }
    }


    public void LoadUpgradesData()
    {
        this.CheckUpgradesUnlock();
    }

    void CheckUpgradesUnlock()
    {
        int numBoughtUpgrades = 0;
        for (int i = 0; i < DataMan.Instance.upgradesData.upgrades.Count; i++)
        {
            if (DataMan.Instance.upgradesData.upgrades[i].Status == ItemState.Bought)
                numBoughtUpgrades++;
        }

        for (int i = 0; i < DataMan.Instance.upgradesData.upgrades.Count; i++)
        {
            if (DataMan.Instance.upgradesData.upgrades[i].Status != ItemState.Bought)
            {
                if (gameUpgrades.upgrades[i].upgradesToUnlock <= numBoughtUpgrades)
                    DataMan.Instance.upgradesData.upgrades[i].Status = ItemState.Unlock;
            }
        }
    }


    public bool OnBuyNewLevelUpgrade(int upgradeID)
    {
        int nextLevel = DataMan.Instance.upgradesData.upgrades[upgradeID].Level + 1;

        if (nextLevel > gameUpgrades.upgrades[upgradeID].upgradesPrices.Count - 1)
        {
            return false;

        }

        if (EconomyMan.Instance.Buy(
            UpgradesMan.Instance.gameUpgrades.upgrades[upgradeID]
            .upgradesPrices[nextLevel]))
        {
            DataMan.Instance.upgradesData.upgrades[upgradeID].Level = nextLevel;

            if (nextLevel == gameUpgrades.upgrades[upgradeID].upgradesPrices.Count - 1)
            {
                DataMan.Instance.upgradesData.upgrades[upgradeID].Status = ItemState.MaxLevel;
            }
            return true;
        }

        return false;

        
    } 

    public bool OnBuyUpgrade(int upgradeID)
    {
        if (EconomyMan.Instance.Buy(
            gameUpgrades.upgrades[upgradeID].upgradesPrices[0]))
        {

            DataMan.Instance.upgradesData.upgrades[upgradeID].Status = ItemState.Bought;
            this.CheckUpgradesUnlock();
            EventsMan.Instance.Call_OnBuyUpgrade(upgradeID);

            return true;
        }

        return false;
    }

    public void OnEquipUpgrade(int upgradeID)
    {
        DataMan.Instance.upgradesData.slots[DataMan.Instance.upgradesData.LastUpdateSlot].SlotUpgrade = upgradeID;
        DataMan.Instance.upgradesData.LastUpdateSlot++;

        if (DataMan.Instance.upgradesData.LastUpdateSlot > Constants.num_upgrade_slots - 1)
            DataMan.Instance.upgradesData.LastUpdateSlot = 0;

        DataMan.Instance.SaveAll();
    }

    public void OnDiscardUpgrade(int upgradeID)
    {
        for (int i = 0; i < Constants.num_upgrade_slots; i++)
        {
            if (DataMan.Instance.upgradesData.slots[i].SlotUpgrade == upgradeID)
            {
                DataMan.Instance.upgradesData.slots[i].SlotUpgrade = (int)eUpgrade.NONE;
                break;
            }

        }

        DataMan.Instance.SaveAll();
    }

    public int GetStatusByID(int idU)
    {
        return DataMan.Instance.upgradesData.upgrades[idU].Status;
    }

}
