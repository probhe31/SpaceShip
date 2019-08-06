using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameScreen : UIScreen
{
    public UIPausePopup pausePopup;
    public Hud hud;
    public UICarouselMissions uiCarouselMission;
    public GameObject containerUpgrades;
    public GameObject hudCanvas;
    public GameObject pauseCanvas;

    private void Start()
    {
        OnEnter();
    }

    public override void OnEnter()
    {
        if (EconomyMan.Instance == null)
            return;

        this.hud.cookies.SetText("" + EconomyMan.Instance.Cookies);
        this.uiCarouselMission.Show();
    }

    public override void OnExit()
    {
    }

    public void OnGameOverWithRespawnOption()
    {
        UIBuyLifePopup buyLifePopup = GameObject.Instantiate(PoolMan.Instance.uiBuyLifePopupPrefab).GetComponent<UIBuyLifePopup>();
        buyLifePopup.transform.SetParent(this.hudCanvas.transform);
        buyLifePopup.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        buyLifePopup.GetComponent<RectTransform>().localScale = Vector3.one;

        if (EconomyMan.Instance.CanBuy(new Money(Constants.price_respawn, Currency.COOKIE)) || AdsMan.Instance.IsAvailable())
        {
            buyLifePopup.Open(AfterBuyLifesPopup);
        }
        else
        {
            AfterBuyLifesPopup(false);
        }
    }

    public void OnGameOver()
    {
        AfterBuyLifesPopup(false);
    }

    void AfterBuyLifesPopup(bool respawn)
    {
        if (respawn)
            return; 

        if (MissionMan.Instance.ShouldShowMissionAfterGamePopup)
        {
            this.OpenGameMissionPopup();
        }
        else
        {
            ScreenMan.Instance.OpenScene(Screens.GameOverScreen);
        }
    }
    
    public void OpenGameMissionPopup()
    {
        UIPostGameMissionsPopup uiPostGameMissionsPopup = GameObject.Instantiate(PoolMan.Instance.uiMissionsPopupPrefab).GetComponent<UIPostGameMissionsPopup>();
        uiPostGameMissionsPopup.transform.SetParent(this.hudCanvas.transform);
        uiPostGameMissionsPopup.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        uiPostGameMissionsPopup.GetComponent<RectTransform>().localScale= Vector3.one;
        uiPostGameMissionsPopup.Open();
    }

    

    

    public void OnClickPauseButton()
    {
        if (Game.Instance.isGameOver)
            return;

        if (!pausePopup)
        {
            pausePopup = GameObject.Instantiate(PoolMan.Instance.uiPausePopupPrefab).GetComponent<UIPausePopup>();
            pausePopup.transform.SetParent(this.pauseCanvas.transform);
            pausePopup.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            pausePopup.GetComponent<RectTransform>().localScale = Vector3.one;
        }
        
        pausePopup.Open();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnClickPauseButton();
        }
    }
}
