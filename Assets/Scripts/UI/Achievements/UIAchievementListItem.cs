using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIAchievementListItem : MonoBehaviour
{
    public GameObject collectBtn;
    public GameObject pendingImg;
    public GameObject collectedImg;
    public Text nameTxt;
    public Text descriptionTxt;
    public Image insigniaImg;
    Achievement myachievement;

    public void Load(Achievement achievement)
    {
        this.myachievement = achievement;
        this.UpdateState();
    }


    void UpdateState()
    {
        this.collectBtn.SetActive(false);
        this.pendingImg.SetActive(false);
        this.collectedImg.SetActive(false);

        this.nameTxt.text = this.myachievement.GetName();
        this.descriptionTxt.text = this.myachievement.GetDescription();
        this.insigniaImg.sprite = this.myachievement.insignia;


        if (this.myachievement.IsComplete)
        {
            if (this.myachievement.IsCollected)
            {
                collectedImg.SetActive(true);
            }
            else
            {
                collectBtn.SetActive(true);
                collectBtn.GetComponent<Button>().onClick.AddListener(OnClickCollectBtn);
            }
        }
        else
        {
            pendingImg.SetActive(true);
        }
    }


    public void OnClickCollectBtn()
    {
        AchievementMan.Instance.OnCollectRewardFrom(myachievement.idAchievement);
        UpdateState();
    }
}
