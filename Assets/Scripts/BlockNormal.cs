using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockNormal : Block
{
    int totalHazardsW = 0;

    public override void OnInitialize()
    {
        base.OnInitialize();

        switch (parameter)
        {
            case 1:
                Game.Instance.levelGenerator.CreateLaser(this);
                break;

            case 2:
                Game.Instance.levelGenerator.CreateMissileHazard(this);
                break;

            default:
                break;
        }
    }


    
}
