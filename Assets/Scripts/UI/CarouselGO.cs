using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarouselGO : MonoBehaviour
{

    int currentItem = 0;
    [HideInInspector]
    public DataCarouselGO dataCarouselGO;
    public Transform spawningPoint;
    bool filled = false;

    public int numItems = 0;

    private void Start()
    {
        //FillItems();
        dataCarouselGO = this.GetComponent<DataCarouselGO>();
        //dataCarouselGO.UpdateData(0);
    }

    public void FillOrShow()
    {
        dataCarouselGO = this.GetComponent<DataCarouselGO>();


        if (!this.filled)
        {
            this.numItems = FillItems();
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(true);
        }

        this.dataCarouselGO.UpdateData(this.currentItem);
    }

    public int FillItems()
    {
        this.filled = true;
        return dataCarouselGO.FillItems(spawningPoint, this);
    }

    public void NextItem()
    {
        this.dataCarouselGO.HideItem(this.currentItem);

        this.currentItem++;
        if (this.currentItem == numItems)
            this.currentItem = 0;

        this.dataCarouselGO.UpdateData(this.currentItem);
    }

    public void PrevItem()
    {
        this.dataCarouselGO.HideItem(this.currentItem);

        currentItem--;
        if (this.currentItem < 0)
            this.currentItem = numItems-1;

        this.dataCarouselGO.UpdateData(this.currentItem);

    }
}
