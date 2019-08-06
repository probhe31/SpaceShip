using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.SceneManagement;

public class SceneItem : Editor {
      
    [MenuItem("Scenes/InitScreen")]
    public static void InitScreen()
    {
        OpenScene(Screens.InitScreen);
    }

    [MenuItem("Scenes/LoadingScreen")]
    public static void LoadingScreen()
    {
        OpenScene(Screens.LoadingScreen);
    }

    [MenuItem("Scenes/TitleScreen")]
    public static void TitleScreen()
    {
        OpenScene(Screens.TitleScreen);
    }

    [MenuItem("Scenes/DailyRewardScreen")]
    public static void DailyRewardScreen()
    {
        OpenScene(Screens.DailyRewardScreen);
    }

    [MenuItem("Scenes/MainMenuScreen")]
    public static void MainMenuScreen()
    {
        OpenScene(Screens.MainMenuScreen);
    }

    [MenuItem("Scenes/GameScreen")]
    public static void GameScreen()
    {
        OpenScene(Screens.GameScreen);
    }

    [MenuItem("Scenes/GameOverScreen")]
    public static void GameOverScreen()
    {
        OpenScene(Screens.GameOverScreen);
    }

    [MenuItem("Scenes/StoreScreen")]
    public static void StoreScreen()
    {
        OpenScene(Screens.StoreScreen);
    }

    

    [MenuItem("Scenes/OptionsScreen")]
    public static void OptionsScreen()
    {
        OpenScene(Screens.OptionsScreen);
    }

    [MenuItem("Scenes/CreditsScreen")]
    public static void CreditsScreen()
    {
        OpenScene(Screens.CreditsScreen);
    }

    [MenuItem("Scenes/LotPostGameScreen")]
    public static void LotPostGameScreen()
    {
        OpenScene(Screens.LotPostGameScreen);
    }

    [MenuItem("Scenes/AchievementScreen")]
    public static void AchievementScreen()
    {
        OpenScene(Screens.AchievementScreen);
    }

    static void OpenScene(string name)
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            EditorSceneManager.OpenScene("Assets/scenes/" + name + ".unity");
        }
    }



}
