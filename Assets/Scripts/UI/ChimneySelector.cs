using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimneySelector : MonoBehaviour
{
    public ChimneysCollection chimneysCollection;
    public int currentId;

    public void Next()
    {
        this.currentId++;
        if (this.currentId > chimneysCollection.chimneys.Count - 1)
        {
            this.currentId = 0;
        }
        Show();
    }

    public void Previous()
    {
        this.currentId--;
        if (this.currentId < 0)
        {
            this.currentId = chimneysCollection.chimneys.Count - 1;
        }
        Show();
    }

    void Show()
    {
        Debug.Log("curid " + this.currentId);
    }


}
