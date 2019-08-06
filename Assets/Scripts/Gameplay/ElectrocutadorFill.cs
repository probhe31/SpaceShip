using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectrocutadorFill : MonoBehaviour, IFilleable
{
    public string nameChildPattern;

    public void CreateChild(Block block, Pattern pattern, Transform _pos)
    {
        
        GetElectrocutador(block, pattern, _pos);
    }

    void GetElectrocutador(Block block, Pattern pattern, Transform pos)
    {
        GameObject godefault = TrashMan.spawn(this.nameChildPattern, pos.position);
        godefault.GetComponent<BlockElement>().Initialize(block);

        godefault.transform.rotation = pattern.transform.rotation;
    }
}
