using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UtilitiesCarouselGO : DataCarouselGO
{

    public Text title_txt;
    public Text description_txt;
    public Text price_txt;
    public Text requirement_txt;

    public GameObject buy_btn;
    public GameObject equip_btn;
    public GameObject discard_btn;
    public CarouselGO carouselGO;

    int currentId = 0;

    public override void UpdateData(int idU)
    {
        this.currentId = idU;
        this.requirement_txt.gameObject.SetActive(false);
        this.price_txt.gameObject.SetActive(false);
        this.discard_btn.gameObject.SetActive(false);
        this.equip_btn.SetActive(false);
        this.buy_btn.SetActive(false);

        switch (UpgradesMan.Instance.GetStatusByID(idU))
        {
            case ItemState.Lock:


                this.requirement_txt.gameObject.SetActive(true);
                this.requirement_txt.text = I18N.Instance.GetLocalizedValue("requirement_1").Replace("/VALUE", UpgradesMan.Instance.gameUpgrades.upgrades[idU].upgradesToUnlock.ToString());
                break;

            case ItemState.Unlock:
                this.buy_btn.SetActive(true);
                this.price_txt.gameObject.SetActive(true);
                this.price_txt.text = UpgradesMan.Instance.gameUpgrades.upgrades[idU].upgradesPrices[0].amount.ToString();

                break;
            case ItemState.Bought:

                this.equip_btn.SetActive(true);

                for (int i = 0; i < Constants.num_upgrade_slots; i++)
                {
                    if (this.currentId == DataMan.Instance.upgradesData.slots[i].SlotUpgrade)
                    {
                        this.equip_btn.SetActive(false);
                        this.discard_btn.gameObject.SetActive(true);
                        break;
                    }

                }           
                break;

        }

        title_txt.text = I18N.Instance.GetLocalizedValue(UpgradesMan.Instance.gameUpgrades.upgrades[idU].key_name);
        description_txt.text = I18N.Instance.GetLocalizedValue(UpgradesMan.Instance.gameUpgrades.upgrades[idU].key_description);
        //Debug.Log("cid " + this.currentId);
        itemsStore[this.currentId].gameObject.SetActive(true);
    }



    public override int FillItems(Transform spawn, CarouselGO _carouselGO)
    {
        this.itemsStore = new List<ItemStore>();

        this.carouselGO = _carouselGO;
        for (int i = 0; i < UpgradesMan.Instance.gameUpgrades.upgrades.Count; i++)
        {
            GameObject g = GameObject.Instantiate(UpgradesMan.Instance.gameUpgrades.upgrades[i].prefabUpgradeGO, spawn.position, Quaternion.identity);
            g.SetActive(false);
            itemsStore.Add(g.GetComponent<ItemStore>());
        }

        return itemsStore.Count;
    }


    public void OnClickBuy()
    {
        /*if (EconomyMan.Instance.Buy(
            UpgradesMan.Instance.gameUpgrades.upgrades[this.currentId].price))
        {
            UpgradesMan.Instance.OnBuyUpgrade(this.currentId);
            UpdateData(this.currentId);
        }*/
    }

    public void OnClickBuyUpgrade()
    {
        /*if (EconomyMan.Instance.Buy(
            UpgradesMan.Instance.gameUpgrades.upgrades[this.currentId].price))
        {
            UpgradesMan.Instance.OnBuyUpgrade(this.currentId);
            UpdateData(this.currentId);
        }*/
    }

    public void OnClickDiscard()
    {
        UpgradesMan.Instance.OnDiscardUpgrade(this.currentId);
        UpdateData(this.currentId);
    }


    public void OnClickEquip()
    {
        UpgradesMan.Instance.OnEquipUpgrade(this.currentId);
        UpdateData(this.currentId);
    }

}
