using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITitleScreen : UIScreen
{
    public float waitTime = 2.0f;

    private void Start()
    {
        OnEnter();
    }

    public override void OnEnter()
    {
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(waitTime);
        ScreenMan.Instance.OpenScene(Screens.MainMenuScreen);
    }

    public override void OnExit()
    {
    }
}
