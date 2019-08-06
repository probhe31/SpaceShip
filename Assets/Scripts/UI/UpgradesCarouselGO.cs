
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesCarouselGO : DataCarouselGO
{    
    public Text title_txt;
    public Text description_txt;
    public Text price_txt;
    public Text requirement_txt;
    public GameObject buy_btn;
    public GameObject equip_btn;
    public GameObject levelup_btn;
    public GameObject discard_btn;
    [HideInInspector]
    public CarouselGO carouselGO;
    public Text level_txt;
    int currentId = 0;

    public override void UpdateData(int idU)
    {
        this.currentId = idU;
        this.requirement_txt.gameObject.SetActive(false);
        this.discard_btn.gameObject.SetActive(false);
        this.equip_btn.SetActive(false);
        this.buy_btn.SetActive(false);
        this.levelup_btn.SetActive(false);
        this.level_txt.gameObject.SetActive(false);

        switch (UpgradesMan.Instance.GetStatusByID(idU))
        {
            case ItemState.Lock:
                this.requirement_txt.gameObject.SetActive(true);
                this.requirement_txt.text = I18N.Instance.GetLocalizedValue("requirement_1").Replace("/VALUE", UpgradesMan.Instance.gameUpgrades.upgrades[idU].upgradesToUnlock.ToString());
                break;

            case ItemState.Unlock:
                this.buy_btn.SetActive(true);
                this.price_txt.text = UpgradesMan.Instance.gameUpgrades.upgrades[idU].upgradesPrices[0].amount.ToString();
                break;

            case ItemState.Bought:
                this.levelup_btn.GetComponent<DoubleTextButton>().text1.text = "" + UpgradesMan.Instance.gameUpgrades.upgrades[currentId].upgradesPrices[DataMan.Instance.upgradesData.upgrades[currentId].Level+1].amount;
                this.levelup_btn.GetComponent<DoubleTextButton>().text2.text = "" + I18N.Instance.GetLocalizedValue("level").ToUpper() + " " + (DataMan.Instance.upgradesData.upgrades[currentId].Level+2);
                this.level_txt.gameObject.SetActive(true);
                this.equip_btn.SetActive(true);
                this.levelup_btn.SetActive(true);
                this.level_txt.text = I18N.Instance.GetLocalizedValue("level").ToUpper()+ " " + (DataMan.Instance.upgradesData.upgrades[currentId].Level+1);
                CheckIfUpgradeIsEquiped();
            break;

            case ItemState.MaxLevel:
                this.equip_btn.SetActive(true);
                this.levelup_btn.SetActive(true);
                this.levelup_btn.SetActive(false);
                CheckIfUpgradeIsEquiped();
                break;

        }

        title_txt.text = I18N.Instance.GetLocalizedValue(UpgradesMan.Instance.gameUpgrades.upgrades[idU].key_name);
        description_txt.text = I18N.Instance.GetLocalizedValue(UpgradesMan.Instance.gameUpgrades.upgrades[idU].key_description);
        itemsStore[this.currentId].gameObject.SetActive(true);
    }

    
    void CheckIfUpgradeIsEquiped()
    {
        for (int i = 0; i < Constants.num_upgrade_slots; i++)
        {
            if (this.currentId == DataMan.Instance.upgradesData.slots[i].SlotUpgrade)
            {
                this.equip_btn.SetActive(false);
                this.discard_btn.gameObject.SetActive(true);
                break;
            }
        }
    }


    public override int FillItems(Transform spawn, CarouselGO _carouselGO)
    {
        this.itemsStore = new List<ItemStore>();

        this.carouselGO = _carouselGO;
        for (int i = 0; i < UpgradesMan.Instance.gameUpgrades.upgrades.Count; i++)
        {
            GameObject g = GameObject.Instantiate(
                UpgradesMan.Instance.gameUpgrades.upgrades[i].prefabUpgradeGO, 
                spawn.position, Quaternion.identity);
            g.SetActive(false);
            itemsStore.Add(g.GetComponent<ItemStore>());
        }

        return itemsStore.Count;
    }


    public void OnClickBuy()
    {
        if (UpgradesMan.Instance.OnBuyUpgrade(this.currentId))
        {
            this.UpdateData(this.currentId);
        }
    }

    public void OnClickUpgrade()
    {
        if (UpgradesMan.Instance.OnBuyNewLevelUpgrade(this.currentId))
        {
            this.UpdateData(this.currentId);
        }
    }

    public void OnClickDiscard()
    {
        UpgradesMan.Instance.OnDiscardUpgrade(this.currentId);
        this.UpdateData(this.currentId);
    }


    public void OnClickEquip()
    {
        UpgradesMan.Instance.OnEquipUpgrade(this.currentId);
        this.UpdateData(this.currentId);
    }

}
