using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DataCarouselGO : MonoBehaviour
{
    public List<ItemStore> itemsStore;
    public abstract void UpdateData(int id);
    public abstract int FillItems(Transform pos, CarouselGO carouselGO);
    public void HideItem(int idC)
    {
        itemsStore[idC].gameObject.SetActive(false);
    }

    public void CloseStore()
    {
        for (int i = 0; i < itemsStore.Count; i++)
        {
            HideItem(i);
        }
    }
    
}
