using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameMissions", menuName = "Claus/GameMissions", order = 2)]
public class GameMissions : ScriptableObject
{
    public List<Mission> missions;
}
