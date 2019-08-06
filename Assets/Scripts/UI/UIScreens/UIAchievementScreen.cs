using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAchievementScreen : UIScreen
{
    public GameObject prefabAchievementLine;
    public GameObject linesContainer;

    public void Start()
    {
        OnEnter();
    }


    public override void OnEnter()
    {
        ConstructAchievementLines();
    }


    void ConstructAchievementLines()
    {
        for (int i = 0; i < AchievementMan.Instance.achievements.Count; i++)
        {
            GameObject lines = GameObject.Instantiate(prefabAchievementLine);
            lines.transform.parent = linesContainer.transform;
            lines.GetComponent<UIAchievementListItem>().Load(AchievementMan.Instance.achievements[i]);
        }
    }


    public override void OnExit()
    {
    }


    public void OnClickGoToMenu()
    {
        ScreenMan.Instance.OpenScene(Screens.MainMenuScreen);
    }
}
