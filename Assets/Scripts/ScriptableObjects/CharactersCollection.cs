using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharactersCollection", menuName = "Claus/CharactersCollection", order = 3)]
public class CharactersCollection : ScriptableObject
{
    public List<Character> characters;
}
