using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameWeights", menuName = "Claus/GameWeights", order = 1)]
public class GameWeights : ScriptableObject
{
    public List<LootValue> wallsW;
    public List<LootValue> hazardBlocksW;
    public List<LootValue> chimney_normal_hazards;

    
}
