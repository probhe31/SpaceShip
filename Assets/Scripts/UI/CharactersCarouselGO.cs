using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactersCarouselGO : DataCarouselGO
{
    public Text title_txt;
    public Text price_txt;
    public GameObject buy_btn;
    public GameObject equip_btn;
    [HideInInspector]
    public CarouselGO carouselGO;
    int currentId = 0;
    public GameObject equiped;

    public override void UpdateData(int idU)
    {
        this.currentId = idU;
        this.equip_btn.SetActive(false);
        this.buy_btn.SetActive(false);
        this.equiped.SetActive(false);

        switch (CharacterMan.Instance.GetStatusByID(idU))
        {
            case CharacterState.Lock:
                break;

            case CharacterState.Unlock:
                this.buy_btn.SetActive(true);
                this.price_txt.text = CharacterMan.Instance.charactersCollection.characters[idU].price.amount.ToString();
                break;

            case CharacterState.Bought:
                this.equip_btn.SetActive(true);
                break;

        }

        title_txt.text = CharacterMan.Instance.charactersCollection.characters[idU].characterName; 
        itemsStore[this.currentId].gameObject.SetActive(true);


        if(DataMan.Instance.charactersData.CurrentSkin == idU)
        {
            this.equip_btn.SetActive(false);
            this.equiped.SetActive(true);
        }
    }


    public override int FillItems(Transform spawn, CarouselGO _carouselGO)
    {
        this.itemsStore = new List<ItemStore>();

        this.carouselGO = _carouselGO;
        for (int i = 0; i < CharacterMan.Instance.charactersCollection.characters.Count; i++)
        {
            GameObject g = GameObject.Instantiate(CharacterMan.Instance.charactersCollection
                                                    .characters[i].playerUIPrefab, 
                                                    spawn.position, 
                                                    Quaternion.identity);
            g.transform.rotation = Quaternion.Euler(-180,0,-180);
            g.SetActive(false);
            g.transform.localScale = new Vector3(250, 250, 250);
            itemsStore.Add(g.GetComponent<ItemStore>());
            //CharacterMan
        }

        return itemsStore.Count;
    }


    public void OnClickBuy()
    {
        if (CharacterMan.Instance.OnBuyCharacter(this.currentId))
        {
            this.UpdateData(this.currentId);
        }
    }


    public void OnClickEquip()
    {
        CharacterMan.Instance.OnEquipCharacter(this.currentId);
        this.UpdateData(this.currentId);
    }

}
