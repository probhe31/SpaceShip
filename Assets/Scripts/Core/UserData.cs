using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData:ISaveable
{
    ValueKey<int> _diamonds = new ValueKey<int>("diamonds_key", 0);
    ValueKey<int> _cookies = new ValueKey<int>("cookies_key", 0);
    ValueKey<int> _lotCookies = new ValueKey<int>("lot_cookies_key", 0);
    ValueKey<int> _redLights = new ValueKey<int>("red_lights", 0);
    ValueKey<int> _explosives = new ValueKey<int>("explosives", 0);

    ValueKey<int> _bestScore = new ValueKey<int>("best_score_key", 0);
    ValueKey<int> _lastScore = new ValueKey<int>("last_score_key", 0);
    ValueKey<int> _playerLevel = new ValueKey<int>("_playerLevel", 0);

   
    ValueKey<int> _current_reward_id = new ValueKey<int>("_current_reward_id", 0);
    ValueKey<int> _last_reward_id_claimed = new ValueKey<int>("_last_reward_id_claimed", -1);
    ValueKey<string> _last_date_claim_reward = new ValueKey<string>("_last_date_claim_reward", "");
    ValueKey<bool> _daily_gift_was_init = new ValueKey<bool>("_daily_gift_was_init", false);

    

    public bool DailyGiftWasInit
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _daily_gift_was_init);
            return _daily_gift_was_init.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _daily_gift_was_init);
        }
    }


   

    public string LastDateClaimReward
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _last_date_claim_reward);
            return _last_date_claim_reward.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _last_date_claim_reward);
        }
    }

    public int CurrentRewardId
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _current_reward_id);
            return _current_reward_id.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _current_reward_id);
        }
    }

    public int LastRewardIdClaimed
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _last_reward_id_claimed);
            return _last_reward_id_claimed.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _last_reward_id_claimed);
        }
    }


    public int Explosives
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _explosives);
            return _explosives.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _explosives);
        }
    }

    public int RedLights
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _redLights);
            return _redLights.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _redLights);
        }
    }


    public int Diamonds
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _diamonds);
            return _diamonds.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _diamonds);
        }
    }

    public int Cookies
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _cookies);
            return _cookies.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _cookies);
        }
    }

    public int LotCookies
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _lotCookies);
            return _lotCookies.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _lotCookies);
        }
    }

    public int BestScore
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _bestScore);
            return _bestScore.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _bestScore);
        }
    }

    

    public int LastScore
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _lastScore);
            return _lastScore.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _lastScore);
        }
    }


    public int PlayerLevel
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _playerLevel);
            return _playerLevel.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _playerLevel);
        }
    }




    

    public void LoadData()
    {
        PlayerPrefUtils.LoadValue(ref _cookies);
        PlayerPrefUtils.LoadValue(ref _redLights);
        PlayerPrefUtils.LoadValue(ref _lotCookies);
        PlayerPrefUtils.LoadValue(ref _bestScore);
        PlayerPrefUtils.LoadValue(ref _lastScore);        
        PlayerPrefUtils.LoadValue(ref _playerLevel);        
        PlayerPrefUtils.LoadValue(ref _current_reward_id);
        PlayerPrefUtils.LoadValue(ref _last_reward_id_claimed);
        PlayerPrefUtils.LoadValue(ref _last_date_claim_reward);
        PlayerPrefUtils.LoadValue(ref _explosives);

    }

    public void SetDefaults()
    {
        PlayerPrefUtils.SetDefaultValue(ref _cookies);
        PlayerPrefUtils.SetDefaultValue(ref _redLights);
        PlayerPrefUtils.SetDefaultValue(ref _lotCookies);
        PlayerPrefUtils.SetDefaultValue(ref _bestScore);
        PlayerPrefUtils.SetDefaultValue(ref _lastScore);        
        PlayerPrefUtils.SetDefaultValue(ref _playerLevel);        
        PlayerPrefUtils.SetDefaultValue(ref _current_reward_id);
        PlayerPrefUtils.SetDefaultValue(ref _last_reward_id_claimed);
        PlayerPrefUtils.SetDefaultValue(ref _last_date_claim_reward);
        PlayerPrefUtils.SetDefaultValue(ref _explosives);

    }


}
