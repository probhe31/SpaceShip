using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDailyRewardBox : MonoBehaviour
{
    public Image imageBox;
    public Image disable_imageBox;

    public Text nameBox;
    public Image claimedImage;
    //public Image blockImage;
    public eRewardBoxState state;

    public enum eRewardBoxState{
        UNLOCKED,
        LOCKED,
        CLAIMED
    }

    Reward reward;
    public void SetStateBox(Reward _reward, eRewardBoxState _state, int day)
    {
        this.nameBox.text = I18N.Instance.GetLocalizedValue("day")+" " +day;
        this.reward = _reward;
        this.claimedImage.gameObject.SetActive(false);
        //this.blockImage.gameObject.SetActive(false);
        this.state = _state;

        switch (this.state)
        {
            case eRewardBoxState.UNLOCKED:
                this.imageBox.gameObject.SetActive(true);

                this.disable_imageBox.gameObject.SetActive(false);

                break;

            case eRewardBoxState.LOCKED:
                this.imageBox.gameObject.SetActive(false);

                this.disable_imageBox.gameObject.SetActive(true);
                //this.blockImage.gameObject.SetActive(true);

                break;
            case eRewardBoxState.CLAIMED:
                this.imageBox.gameObject.SetActive(false);


                this.disable_imageBox.gameObject.SetActive(true);

                this.claimedImage.gameObject.SetActive(true);
                break;
            default:
                break;
        }

        this.state = _state;

    }


}
