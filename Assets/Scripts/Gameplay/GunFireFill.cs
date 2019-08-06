using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFireFill : MonoBehaviour, IFilleable
{
    public string nameChildPattern;
    Pattern pattern;
    public void CreateChild(Block _block, Pattern _pattern, Transform _pos)
    {
        this.pattern = _pattern;
        GetNormalFireGun(_block, _pos.position);
        
    }


    void GetNormalFireGun(Block block, Vector3 pos)
    {
        GameObject godefault = TrashMan.spawn(this.nameChildPattern, pos);
        //Debug.Log("euler  " + pattern.transform.eulerAngles);
        godefault.GetComponent<GunFire>().Initialize(block, pattern.direction);
    }


   


}
