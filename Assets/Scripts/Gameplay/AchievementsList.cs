using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsList : MonoBehaviour
{
    public static AchievementsList Instance;


    private void Awake()
    {
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }


    public List<Achievement> achievements = new List<Achievement>
    {
        new EnterChimneyAchievement(
            "achv1_name",
            5,
            new Money(2, Currency.DIAMOND)),
        new EnterChimneyAchievement(
            "achv2_name",
            50,
            new Money(4, Currency.DIAMOND)),
        new EnterChimneyAchievement(
            "achv3_name",
            100,
            new Money(6, Currency.DIAMOND)),
        new EnterChimneyAchievement(
            "achv4_name",
            500,
            new Money(10, Currency.DIAMOND)),
        new EnterChimneyAchievement(
            "achv5_name",
            1000,
            new Money(20, Currency.DIAMOND)),
        new DailyRewardCompletionistAchievement(
            new Money(20, Currency.DIAMOND)),
        new FallNMetersAchievement(
            "achv7_name",
            1000,
            new Money(5, Currency.DIAMOND)),
         new FallNMetersAchievement(
            "achv8_name",
            5000,
            new Money(10, Currency.DIAMOND)),
          new FallNMetersAchievement(
            "achv9_name",
            10000,
            new Money(20, Currency.DIAMOND)),
           new EatNCookiesAchievement(
            "achv10_name",
            500,
            new Money(10, Currency.DIAMOND)),
           new EatNCookiesAchievement(
            "achv11_name",
            2500,
            new Money(20, Currency.DIAMOND)),
           new EatNCookiesAchievement(
            "achv12_name",
            5000,
            new Money(30, Currency.DIAMOND)),
           new EatNCookiesAchievement(
            "achv13_name",
            10000,
            new Money(50, Currency.DIAMOND)),
           new DailyRewardHunterAchievement(
            "achv14_name",
            10,
            new Money(30, Currency.DIAMOND)),
           new DailyRewardHunterAchievement(
            "achv15_name",
            25,
            new Money(30, Currency.DIAMOND)),
           new DailyRewardHunterAchievement(
            "achv16_name",
            30,
            new Money(50, Currency.DIAMOND)),
           new CrazyUpgradesBuyerAchievement(
            new Money(50, Currency.DIAMOND)),
           new ClickOnSecretButtonAchievement(
            new Money(100, Currency.DIAMOND))

    };
}
