using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory 
{
    protected LevelGenerator levelGenerator;
    protected GameWeights gameWeights;

    public Factory(LevelGenerator _levelGenerator, GameWeights _gameWeights)
    {
        this.gameWeights = _gameWeights;
        this.levelGenerator = _levelGenerator;
    }

    protected bool CanCreateById(LootValue v, int meters)
    {
        return meters >= v.range.x
                && (meters < v.range.y || v.range.y == -1);
    }


    protected int CalculateTotalProb(IList<LootValue> lotval, int meters)
    {
        int result = 0;

        for (int i = 0; i < lotval.Count; i++)
        {
            if (CanCreateById(lotval[i], meters))
                result += lotval[i].weight;
        }

        return result;
    }

    protected int GetOneID(IList<LootValue> lotvalList, int meters)
    {
        int random = Random.Range(0, CalculateTotalProb(lotvalList, meters));

        int res = 0;
        int acum = 0;
        for (int i = 0; i < lotvalList.Count; i++)
        {
            if (CanCreateById(lotvalList[i], meters))
            {
                acum += lotvalList[i].weight;
                if (random <= acum)
                {
                    res = i;
                    break;
                }
            }
        }

        return res;
    }
}
