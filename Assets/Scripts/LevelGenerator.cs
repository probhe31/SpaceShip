using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct IntVector
{
    public int x;
    public int y;

    public IntVector(int _x, int _y)
    {
        this.x = _x;
        this.y = _y;
    }
}


[System.Serializable]
public class LootValue
{
    public string name;
    public int weight;
    public int parameter;
    public IntVector range;

    public LootValue(string _name, int _w, IntVector _range, int _parameter)
    {
        this.name = _name;
        this.weight = _w;
        this.range = _range;
        this.parameter = _parameter;
    }
}

public class LevelGenerator : MonoBehaviour
{
    public bool generatingHazard = true;
    public GameWeights gameWeights;
    public GameObject levelContainer;
    BlockFactory blockFactory;
    ObstacleFactory obstacleFactory;
    CookieFactory cookieFactory;

    public BlockFactory BlockFactory
    {
        get
        {
            return blockFactory;
        }
    }

    void Start()
    {
        blockFactory = new BlockFactory(this, gameWeights, levelContainer);
        obstacleFactory = new ObstacleFactory(this, gameWeights);
        cookieFactory = new CookieFactory(this, gameWeights);
        CreateInitWalls();
    }


    void CreateInitWalls()
    {
        CreateNBlocks("block_test_new", 5, false);

    }


    public void CreateLootCookie(Block block)
    {
        GameObject lootCoin = TrashMan.spawn("lootCookie");
        lootCoin.transform.position = block.transform.position;
        lootCoin.GetComponent<LotCookie>().Initialize(block);
    }


    public void CreateOne(bool createHazards = true)
    {
        int meters = Game.Instance.fallDistanceMeter.meters;

        Block block = this.blockFactory.Create(meters);
          

        if (!createHazards)
            return;

        if (!this.generatingHazard)
            return;

        this.obstacleFactory.Create(meters, block);

        CreateRedLigthPattern(block);

        if (counterSpecial % 12 == 0)
        {
            CreateLootCookie(block);
        }
        else
        {
            this.cookieFactory.Create(meters, block);   
        }
               
        counterSpecial++;
        
    }

    public void CreateMissileHazard(Block block)
    {
        if (Game.Instance.fallDistanceMeter.meters > 10)
        {
            GameObject pattern = TrashMan.spawn("gun_fire_pattern_1", block.transform.position);
            pattern.transform.eulerAngles = Vector3.zero;
            pattern.transform.eulerAngles = new Vector3(0, 45, 0);
            pattern.GetComponent<Pattern>().Initialize(block);
        }
    }


    void CreateRedLigthPattern(Block block)
    {
        //if (Random.Range(0, 200) < 50 && Game.Instance.counterMeters.meters > 50)
        //{
            GameObject pattern = TrashMan.spawn("red_light_pattern", block.transform.position);

            pattern.GetComponent<Pattern>().Initialize(block);

        //}
    }
    

   


    int counterSpecial = 1;

    public void CreateNBlocks(string type, int numBlocks, bool createHazards = true)
    {
        for (int i = 0; i < numBlocks; i++)
        {
            CreateOne(createHazards);
        }
    }




    public GameObject CreateLaser(Block block)
    {

        if (UpgradesMan.Instance.HasRuinLasersEnable)
        {
            int prob = Random.Range(0, 100);
            //TODO: ESTO ESTA HARCODEADO se debe cargar a partir del nivel del upgrade
            if (prob > 10)
            {
                Debug.Log("salvado por el ruin laser");
                return null;
            }
        }

        int r = Random.Range(3, 5);
        GameObject internalHazard = TrashMan.spawn(
            Game.Instance.gameWeights.chimney_normal_hazards[r].name,
            this.transform.position);

        internalHazard.transform.eulerAngles = Vector3.zero;
        int probRotation = Random.Range(0, 100);

        if (probRotation < 50)
        {
            internalHazard.transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else
        {
            internalHazard.transform.rotation = Quaternion.Euler(0, -45, 0);
        }

        internalHazard.GetComponent<BlockElement>().Initialize(block);

        return internalHazard;
    }

}
