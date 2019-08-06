using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChimneysCollection", menuName = "Claus/ChimneysCollection", order = 6)]
public class ChimneysCollection : ScriptableObject
{
    public List<Chimney> chimneys;
}
