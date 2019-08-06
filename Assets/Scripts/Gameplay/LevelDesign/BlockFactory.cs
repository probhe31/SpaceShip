using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFactory: Factory
{
    Queue<Block> blocks;
    GameObject levelContainer;
    int idPrevWall = 0;
    int idCurWall = 0;
    
    public Block lastBlock;


    public Block GetFirstBlock()
    {
        return blocks.Peek();
    }

    public BlockFactory(LevelGenerator _levelGenerator, GameWeights _gameWeights, GameObject _levelContainer):base(_levelGenerator, _gameWeights)
    {
        this.levelContainer = _levelContainer;
        this.blocks = new Queue<Block>();
    } 


    public Block Create(int meters)
    {
        int res = GetOneID(gameWeights.wallsW, meters);

        this.idPrevWall = idCurWall;
        this.idCurWall = res;

        GameObject wall = TrashMan.spawn(gameWeights.wallsW[res].name);
        wall.transform.parent = levelContainer.transform;
        wall.transform.eulerAngles = new Vector3(-90, 0, 0);

        return GetBlockFromWall(wall, res);
    }
    

    Block GetBlockFromWall(GameObject wall, int res)
    {
        Block block = wall.GetComponent<Block>();

        if (lastBlock)
            block.Initialize(this, lastBlock.endPoint.position, gameWeights.wallsW[res].parameter);
        else
            block.Initialize(this, Vector3.zero, gameWeights.wallsW[res].parameter);

        this.lastBlock = block;
        this.blocks.Enqueue(block);

        return block;
    }

    public void Remove()
    {
        Block block = blocks.Dequeue();
        block.gameObject.transform.parent = null;
        TrashMan.despawn(block.gameObject);

        this.levelGenerator.CreateOne();
    }
}
