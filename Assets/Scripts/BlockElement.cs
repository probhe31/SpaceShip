using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BlockElement : MonoBehaviour
{

    public Block block;

    public void Initialize(Block _block)
    {
        this.block = _block;
        this.block.blockElements.Add(this);
        this.transform.parent = _block.gameObject.transform;

        this.OnInitialize();

    }



    public virtual void OnInitialize()
    {

    }

    public bool CanKill()
    {
        return true;
    }

    public void Kill()
    {
        this.OnKill();
        this.gameObject.transform.parent = null;
        TrashMan.despawn(this.gameObject);        
    }


    

    public virtual void OnKill()
    {

    }
}
