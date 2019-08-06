using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tags
{
    public const string Hazard = "Hazard";
    public const string Cookie = "Cookie";
    public const string ImprovedCookie = "ImprovedCookie";
    public const string LotCookie = "LotCookie";
    public const string RedLight = "RedLight";
    public const string Player = "Player";
    public const string WallObstacle = "WallObstacle";
}


public static class ItemState
{
    public const int Lock = 0;
    public const int Unlock = 1;
    public const int Bought = 2;
    public const int MaxLevel = 3;
}


public static class CharacterState
{
    public const int Lock = 0;
    public const int Unlock = 1;
    public const int Bought = 2;
  
}

public static class Screens
{
    public static string InitScreen = "InitScreen";
    public static string LoadingScreen = "LoadingScreen";
    public static string TitleScreen = "TitleScreen";
    public static string MainMenuScreen = "MainMenuScreen";
    public static string GameScreen = "GameScreen";
    public static string GameOverScreen = "GameOverScreen";
    public static string ChallengeCompletedScreen = "ChallengeCompletedScreen";
    public static string ChallengeFailedScreen = "ChallengeFailedScreen";
    public static string CreditsScreen = "CreditsScreen";
    public static string OptionsScreen = "OptionsScreen";
    public static string StoreScreen = "StoreScreen";
    public static string UpgradesStoreScreen = "UpgradesStoreScreen";
    public static string CharactersStoreScreen = "CharactersStoreScreen";
    public static string UtilitiesStoreScreen = "UtilitiesStoreScreen";
    public static string LotPostGameScreen = "LotPostGameScreen";
    public static string DailyRewardScreen = "DailyRewardScreen";
    public static string AchievementScreen = "AchievementScreen";
    //public static string MissionsPostGameScreen = "MissionsPostGameScreen";
}


public static class Constants
{
    #region LANGUAGE

 
    public const string ES = "es";
    public const string EN = "en";
    public static readonly string[] languages = { "English", "Español" };
    public static readonly string[] languages_res = { "en", "es" };
    #endregion


    public static int magneticCookiesLM = LayerMask.GetMask("CookiesMagneticArea");
    public const int amount_improved_cookies = 6;

    public const int num_upgrade_slots = 2;
    public const int num_upgrades = 6;
    public const int num_missions_per_level = 3;
    public const int num_secret_buttons = 3;

    public const int price_respawn = 10;
}


