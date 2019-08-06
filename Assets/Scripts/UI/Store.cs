using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public CarouselGO carousel;
    

    public void FillOrShow()
    {
        this.carousel.FillOrShow();
        this.gameObject.SetActive(true);
    }

    public void CloseStore()
    {
        carousel.dataCarouselGO.CloseStore();
    }
}
