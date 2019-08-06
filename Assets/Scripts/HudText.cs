using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HudText : MonoBehaviour
{
    public Text myText;

    private void Awake()
    {
        this.myText = this.GetComponent<Text>();
    }

    public void SetText(string text)
    {
        this.myText.text = text;
    }

    


    public void SetTextWithTweenScale(string text)
    {
        this.myText.transform.DOKill();
        this.myText.transform.localScale = Vector3.one;
        this.myText.text = text;
        this.myText.transform.DOScale(1.2f, 0.2f).SetEase(Ease.InOutSine).SetLoops(2, LoopType.Yoyo);
        
    }
}
