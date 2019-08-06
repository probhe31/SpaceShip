using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern : BlockElement
{
    public List<Transform> positions;

    public IFilleable filleable;

    public int direction = -1;

    /**/


    public void Initialize(Block _block, int dir)
    {
        base.Initialize(_block);
        this.direction = dir;
    }

    public override void OnInitialize()
    {
        base.OnInitialize();

        this.transform.localEulerAngles = new Vector3(90, 90, 90);
        /*int probRotation = Random.Range(0, 100);

        if (probRotation < 50)
        {
            this.transform.localRotation = Quaternion.Euler(new Vector3(90, 90, 0));
        }
        else
        {
            this.transform.localRotation = Quaternion.Euler(new Vector3(180, 90, 0));
        }*/


        this.filleable = this.GetComponent<IFilleable>();
        FillWith();
        
    }

    public void FillWith()
    {
        for (int i = 0; i < positions.Count; i++)
        {
            filleable.CreateChild(block, this,  positions[i]);
        }
    }
}
