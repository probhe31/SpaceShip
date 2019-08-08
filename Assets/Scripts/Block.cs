using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Transform starPoint;
    public Transform endPoint;    
    public float heigh = 6;
    public List<BlockElement> blockElements = new List<BlockElement>();
    bool die = false;
    protected int parameter = 0;
    BlockFactory iFactory;
  

    public virtual void OnInitialize()
    {
        Vector3 newrot = this.transform.localRotation.eulerAngles;
        newrot.y = 0;        
        this.transform.localRotation = Quaternion.Euler(newrot);
    }
           
    
    public void Initialize(BlockFactory _ifactory, Vector3 lastEndPoint, int _parameter = 0)
    {
        this.iFactory = _ifactory;
        this.parameter = _parameter;

        Vector3 p = lastEndPoint + (Vector3.forward * (heigh / 2));
        p.z = Mathf.Round(p.z);       
        this.transform.position = p;
        die = false;
        OnInitialize();
    }


    private void Update()
    {
        if(endPoint.position.z < Game.Instance.mainCameraTransform.position.z)
        {
            Kill();
        }
    }


    public void Kill()
    {        
        if (this.die)
            return;

        this.die = true;

        this.RemoveBlockElements();

        this.iFactory.Remove();

        
    }

    void RemoveBlockElements()
    {
        for (int i = 0; i < blockElements.Count; i++)
        {
            blockElements[i].Kill();
        }

        blockElements.Clear();
    }

}
