using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLightFill : MonoBehaviour, IFilleable
{
    public string nameChildPattern;

    public void CreateChild(Block _block, Pattern pattern, Transform _pos)
    {
        GetRedLight(_block, _pos.position);
    }


    void GetRedLight(Block block, Vector3 pos)
    {
        GameObject redLight = TrashMan.spawn(this.nameChildPattern, pos);
        redLight.GetComponent<BlockElement>().Initialize(block);
        redLight.transform.localEulerAngles = new Vector3(0, 0, 0);

    }
}
