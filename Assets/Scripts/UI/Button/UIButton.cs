using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;


public class UIButton : EventTrigger
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        this.transform.DOScale(0.9f, 0.2f);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        this.transform.DOScale(1f, 0.35f).SetEase(Ease.OutBack);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        this.transform.DOScale(1f, 0.35f).SetEase(Ease.OutBack);
    }

}
