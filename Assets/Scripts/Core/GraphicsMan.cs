using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsMan : MonoBehaviour
{
    bool isFullscreen = false;
    int scale = 1;

    public static GraphicsMan Instance;
    private void Awake()
    {
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        Limit60FPS();
    }


    public void DisableVSync()
    {
        QualitySettings.vSyncCount = 0;
    }

    public void EnableVSync()
    {
        QualitySettings.vSyncCount = 1;
        Limit60FPS();
    }


    public void Limit60FPS()
    {
        Application.targetFrameRate = 60;
    }

}
