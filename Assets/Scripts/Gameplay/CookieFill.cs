using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieFill : MonoBehaviour, IFilleable
{
    public string nameChildPattern;
    [Header("alternative")]
    public string nameAltChildPattern1;
    public float prob1 = 10;



    public void CreateChild(Block _block, Pattern pattern, Transform _pos)
    {
        if (UpgradesMan.Instance.HasImprovedCookiesEnable)
        {
            int prob = Random.Range(0, 100);
            if (prob < this.prob1)
            {
                GetImprovedCookie(_block, _pos.position);
            }
            else
            {
                GetNormalCookie(_block, _pos.position);
            }
        }
        else
        {
            GetNormalCookie(_block, _pos.position);
        }
    }


    void GetNormalCookie(Block block, Vector3 pos)
    {
        GameObject godefault = TrashMan.spawn(this.nameChildPattern, pos);
        godefault.GetComponent<BlockElement>().Initialize(block);
    }
    

    void GetImprovedCookie(Block block, Vector3 pos)
    {
        GameObject goalt = TrashMan.spawn(this.nameAltChildPattern1, pos);
        goalt.GetComponent<BlockElement>().Initialize(block);
    }


}
