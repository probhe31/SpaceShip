using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockExplosion : MonoBehaviour, IExplotable
{
    public GameObject myself;
    public void OnExplode()
    {
        myself.SetActive(false);
    }
}
