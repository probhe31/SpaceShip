using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsMan : MonoBehaviour
{
    public static AdsMan Instance;
#if UNITY_IOS
        private string gameId = "3214648";
#elif UNITY_ANDROID
        private string gameId = "3214649";
#else
        private string gameId = "3214649";
#endif
    bool testMode = true;

    public FastRespawnEvent fastRespawnEvent;
    public DailyRewardx2Event dailyRewardx2Event;

    private void Awake()
    {
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        Advertisement.Initialize(gameId, testMode);

        fastRespawnEvent = new FastRespawnEvent();
        Advertisement.AddListener(fastRespawnEvent);

        dailyRewardx2Event = new DailyRewardx2Event();
        Advertisement.AddListener(dailyRewardx2Event);
    }


    public bool IsAvailable()
    {
        return Advertisement.IsReady(gameId);
    }

}
