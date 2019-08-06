using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementMan : MonoBehaviour
{
    bool showAlert = false;
    public static AchievementMan Instance;
    public List<Achievement> achievements;


    private void Awake()
    {
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        achievements = AchievementsList.Instance.achievements;
        Initialize();
    }

    public void Initialize()
    {
        for (int i = 0; i < achievements.Count; i++)
        {
            achievements[i].Load(
                i, 
                DataMan.Instance.achievementsData.achievements[i].IsCollected, 
                DataMan.Instance.achievementsData.achievements[i].IsComplete);
        }
    }

    public bool IsThereAnyPendingToCollect()
    {
        bool res = true;
        for (int i = 0; i < achievements.Count; i++)
        {
            res = IsPendingCollect(i);
        }

        return res;
    }

    public bool IsPendingCollect(int _idAchievement)
    {
        return achievements[_idAchievement].IsComplete && !achievements[_idAchievement].IsCollected;
    }

    public void ReportCompleteAchievement(int idAchievement)
    {
    }

    public void OnCollectRewardFrom(int idAchievement)
    {
        achievements[idAchievement].Collect();
       
    }
}
