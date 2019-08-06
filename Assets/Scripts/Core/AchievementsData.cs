using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsData : ISaveable
{
    public List<AchievementData> achievements;
    int countAchievements = 0;
    ValueKey<int> _acum_chimney_enters = new ValueKey<int>("_acum_chimney_enters", 0);
    ValueKey<int> _acum_fall_meters = new ValueKey<int>("_acum_fall_meters", 0);
    ValueKey<int> _acum_cookies = new ValueKey<int>("_acum_cookies", 0);
    ValueKey<int> _acum_explosives = new ValueKey<int>("_acum_explosives", 0);
    ValueKey<int> _acum_daily_reward = new ValueKey<int>("_acum_daily_reward", 0);
    public List<SecretButtonData> secrets;


    public AchievementsData(int count)
    {
        this.countAchievements = count;
        this.achievements = new List<AchievementData>();
        for (int i = 0; i < this.countAchievements; i++)
        {
            this.achievements.Add(new AchievementData(i));
        }

        this.secrets = new List<SecretButtonData>();
        for (int i = 0; i < Constants.num_secret_buttons; i++)
        {
            this.secrets.Add(new SecretButtonData(i));
        }
    }

    public int Explosives_Accumulator
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _acum_explosives);
            return _acum_explosives.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _acum_explosives);
        }
    }


    public int Daily_Reward_Accumulator
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _acum_daily_reward);
            return _acum_daily_reward.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _acum_daily_reward);
        }
    }

    public int Cookies_Accumulator
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _acum_cookies);
            return _acum_cookies.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _acum_cookies);
        }
    }

    public int Fall_Meters_Accumulator
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _acum_fall_meters);
            return _acum_fall_meters.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _acum_fall_meters);
        }
    }

    public int Enter_Chimney_Accumulator
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _acum_chimney_enters);
            return _acum_chimney_enters.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _acum_chimney_enters);
        }
    }


    public void LoadData()
    {
        PlayerPrefUtils.LoadValue(ref _acum_chimney_enters);
        PlayerPrefUtils.LoadValue(ref _acum_fall_meters);
        PlayerPrefUtils.LoadValue(ref _acum_cookies);
        PlayerPrefUtils.LoadValue(ref _acum_daily_reward);
        PlayerPrefUtils.LoadValue(ref _acum_explosives);
        

        for (int i = 0; i < this.countAchievements; i++)
        {
            achievements[i].LoadData();
        }

        for (int i = 0; i < Constants.num_secret_buttons; i++)
        {
            secrets[i].LoadData();
        }
    }

    public void SetDefaults()
    {
        PlayerPrefUtils.SetDefaultValue(ref _acum_chimney_enters);
        PlayerPrefUtils.SetDefaultValue(ref _acum_fall_meters);
        PlayerPrefUtils.SetDefaultValue(ref _acum_fall_meters);
        PlayerPrefUtils.SetDefaultValue(ref _acum_daily_reward);
        PlayerPrefUtils.SetDefaultValue(ref _acum_explosives);


        for (int i = 0; i < this.countAchievements; i++)
        {
            achievements[i].SetDefaults();
        }

        for (int i = 0; i < Constants.num_secret_buttons; i++)
        {
            secrets[i].SetDefaults();
        }
    }
}
