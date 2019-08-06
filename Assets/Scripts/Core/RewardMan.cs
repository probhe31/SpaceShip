using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardMan : MonoBehaviour
{

    public static RewardMan Instance;
    public DailyRewardSystem dailyRewardSystem;

    private void Awake()
    {
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        this.dailyRewardSystem = this.GetComponent<DailyRewardSystem>();
    }

    public List<Reward> GetRewardMissions()
    {
        return new List<Reward>()
        {
            new Reward(eReward.COOKIE, 50),
        };
    }

}
