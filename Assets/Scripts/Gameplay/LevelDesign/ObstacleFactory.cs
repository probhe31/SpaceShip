using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFactory : Factory
{

    public ObstacleFactory(LevelGenerator _levelGenerator, GameWeights _gameWeights):base(_levelGenerator, _gameWeights)
    {

    }


    public BlockElement Create(int meters, Block block)
    {
        int res = GetOneID(gameWeights.hazardBlocksW, meters);
        if (gameWeights.hazardBlocksW[res].name != "null")
        {
            GameObject hazard = TrashMan.spawn(gameWeights.hazardBlocksW[res].name, block.endPoint.position);
            hazard.GetComponent<Obstacle>().Initialize(block);
            return hazard.GetComponent<BlockElement>();
        }

        return null;
        
    }


    

}
