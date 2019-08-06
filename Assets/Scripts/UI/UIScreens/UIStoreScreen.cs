using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStoreScreen : UIScreen
{
    public Store characters_store;
    public Store utilities_store;
    public Store upgrades_store;
    GameObject currentStore;

    public Button characterBtn;
    public Button upgradeBtn;
    public Button utilitiesBtn;

    public Sprite onButtonSprite;
    public Sprite offButtonSprite;

    private void Start()
    {
        OnEnter();
    }

    public override void OnEnter()
    {
        OnClickUpgradesBtn();
    }

    public override void OnExit()
    {
    }

    public void OnClickCharactersBtn()
    {
        if (this.currentStore)
        {
            this.currentStore.GetComponent<Store>().CloseStore();
            this.currentStore.SetActive(false);

        }
        characterBtn.image.sprite = onButtonSprite;
        upgradeBtn.image.sprite = offButtonSprite;
        utilitiesBtn.image.sprite = offButtonSprite;


        this.currentStore = characters_store.gameObject;
        this.characters_store.FillOrShow();

    }

    public void OnClickUpgradesBtn()
    {
        if (this.currentStore)
        {
            this.currentStore.GetComponent<Store>().CloseStore();
            this.currentStore.SetActive(false);

        }
        characterBtn.image.sprite = offButtonSprite;
        upgradeBtn.image.sprite = onButtonSprite;
        utilitiesBtn.image.sprite = offButtonSprite;


        this.currentStore = upgrades_store.gameObject;
        this.upgrades_store.FillOrShow();
    }

    public void OnClickUtilitiesBtn()
    {
        if (this.currentStore)
        {
            this.currentStore.GetComponent<Store>().CloseStore();
            this.currentStore.SetActive(false);

        }

        characterBtn.image.sprite = offButtonSprite;
        upgradeBtn.image.sprite = offButtonSprite;
        utilitiesBtn.image.sprite = onButtonSprite;

        this.currentStore = utilities_store.gameObject;
        this.utilities_store.FillOrShow();

    }

    public void OnClickGoToMainMenuBtn()
    {
        ScreenMan.Instance.OpenScene(Screens.MainMenuScreen);
    }



}
