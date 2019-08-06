using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMan : MonoBehaviour
{
    public static PoolMan Instance;
    public GameObject uiPausePopupPrefab;
    public GameObject uiMissionsPopupPrefab;
    public GameObject uiMissionGiftPopupPrefab;
    public GameObject uiBuyLifePopupPrefab;


    private void Awake()
    {
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public List<GameObject> poolActive = new List<GameObject>();

    public void ReturnToPool(GameObject go)
    {
        for (int p = 0; p < poolActive.Count; p++)
        {
            TrashMan.despawn(poolActive[p]);
            poolActive.RemoveAt(p);
        }
    }

    public GameObject GetRemoveActor(Vector3 position)
    {
        return null;
    }


    public GameObject GetTileBase()
    {
        return null;
    }

    public void RemoveActor(GameObject go)
    {

    }

    public GameObject GetBubble(Vector3 pos)
    {
        GameObject bubble = TrashMan.spawn("bubble", pos);
        this.poolActive.Add(bubble);
        return bubble;
    }

    public GameObject GetExplosion(Vector3 pos)
    {
        GameObject explosion = TrashMan.spawn("explo_1", pos);
        this.poolActive.Add(explosion);
        return explosion;
    }

    public GameObject GetTile(Vector3 pos)
    {
        GameObject tile = TrashMan.spawn("tile", pos);
        this.poolActive.Add(tile);
        return tile;
    }

    public GameObject GetTile()
    {
        GameObject tile = TrashMan.spawn("tile");
        this.poolActive.Add(tile);
        return tile;
    }

    public GameObject GetPoint(Vector3 pos)
    {
        GameObject point = TrashMan.spawn("point", pos);
        this.poolActive.Add(point);
        return point;
    }

}
