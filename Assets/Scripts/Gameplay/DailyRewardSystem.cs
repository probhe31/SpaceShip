using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class DailyRewardSystem : MonoBehaviour
{

    public int daysToBreakDailyGif = 3;
    //public int rewardDay = 0;
    public int numGifts = 5;

    public List<Reward> rewards = new List<Reward>()
    {
        new Reward(eReward.COOKIE, 10),
        new Reward(eReward.COOKIE, 50),
        new Reward(eReward.COOKIE, 100),
        new Reward(eReward.DIAMOND, 2),
        new Reward(eReward.BOX, 1)
    };

    private void Start()
    {
        Analize();
    }

   
    public void Analize()
    {
        DateTime now = Now();

        if (!DataMan.Instance.userData.DailyGiftWasInit)
        {
            #region first_day
            DataMan.Instance.userData.DailyGiftWasInit = true;
            DataMan.Instance.userData.LastRewardIdClaimed = -1;
            DataMan.Instance.userData.CurrentRewardId = 0;
            #endregion
        }
        else
        {
            #region regular_day
            DateTime lastDateClaimReward = now;

            DateTime.TryParse(DataMan.Instance.userData.LastDateClaimReward, out lastDateClaimReward);


            int daysFromLastAccess = Math.Abs(now.Subtract(lastDateClaimReward).Days);

            if (!HasReward() && daysFromLastAccess >= 1)
            {
                DataMan.Instance.userData.CurrentRewardId++;
                if(DataMan.Instance.userData.CurrentRewardId == numGifts)
                {
                    DataMan.Instance.userData.LastRewardIdClaimed = -1;
                    DataMan.Instance.userData.CurrentRewardId = 0;
                }


                if (DataMan.Instance.userData.CurrentRewardId == numGifts-1)
                {
                    EventsMan.Instance.Call_OnCompleteDailyReward();
                }

            }


            #endregion
        }


        
    }


    public bool HasReward()
    {
        return DataMan.Instance.userData.CurrentRewardId != DataMan.Instance.userData.LastRewardIdClaimed;
    }

    

    public Reward ClaimReward(int factor)
    {
        if (!HasReward())
            return new Reward(eReward.NONE, -1);

        DataMan.Instance.userData.LastDateClaimReward = Now().ToString();
        DataMan.Instance.userData.LastRewardIdClaimed = DataMan.Instance.userData.CurrentRewardId;
        Reward newReward = rewards[DataMan.Instance.userData.CurrentRewardId];
        newReward.amount *= factor;
        return newReward;

        

    }


    public DateTime Now()
    {
        bool hasInternetConeccion = false;

        if (hasInternetConeccion)
        {
           
            /*UnityWebRequest www = UnityWebRequest.Get("http://www.my-server.com");
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Show results as text
                Debug.Log(www.downloadHandler.text);

                // Or retrieve results as binary data
                byte[] results = www.downloadHandler.data;
            }
            */

            return DateTime.Now;
        }
        else
        {
            return DateTime.Now;
        }
    }



}
