using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMan : MonoBehaviour
{

    public static InputMan Instance;
    private void Awake()
    {
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

}
