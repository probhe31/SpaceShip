using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle5 : Obstacle
{
    public List<Transform> positions;

    public override void OnInitialize()
    {
        if (Random.Range(0, 100) < 50)
            this.GetComponent<RotateAnimation>().direction = new Vector3(0, 5, 0);
        else
            this.GetComponent<RotateAnimation>().direction = new Vector3(0, -5, 0);


        this.transform.eulerAngles = new Vector3(0, 0, 0);

        if (Random.Range(0, 100) < 50 && Game.Instance.fallDistanceMeter.meters > 30)
        {
            int num = Random.Range(0, 4);
            for (int i = 0; i < num; i++)
            {
                GameObject cueton = TrashMan.spawn("cueton", positions[i].position);
                block.blockElements.Add(cueton.GetComponent<BlockElement>());
            }
        }

        base.OnInitialize();

    }


}

