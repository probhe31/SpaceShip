using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSDisplay : MonoBehaviour
{    
    string label = "";
    float count;

    IEnumerator Start()
    {
        GUI.depth = 2;
        while (true)
        {
            if (Time.timeScale == 1)
            {
                yield return new WaitForSeconds(0.1f);
                count = (1 / Time.deltaTime);
                //label = "FPS :" + (Mathf.Round(count)) + " " +TimeMan.Instance.timeMult;
                label = "FPS :" + (Mathf.Round(count));
            }
            else
            {
                label = "Pause";
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(5, 40, 300, 25), label);
    }
}
