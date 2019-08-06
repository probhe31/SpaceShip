using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SquashStrech : MonoBehaviour
{
    public void OnHit()
    {

        if (DOTween.IsTweening(this.gameObject))
            return;
        this.transform.localScale = Vector3.one;
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(this.transform.DOScale(new Vector3(1.2f, 1f, 1.1f), 0.2f));
        mySequence.Append(this.transform.DOScale(new Vector3(1.32f, 1f, 1f), 0.2f));
        mySequence.Append(this.transform.DOScale(new Vector3(1.2f, 1f, 1.1f), 0.2f));
        mySequence.Append(this.transform.DOScale(new Vector3(1.32f, 1f, 1f), 0.2f));
    }



}
