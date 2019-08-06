using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMan : MonoBehaviour
{
    public static DataMan Instance;

    public UserData userData;
    public OptionsData optionsData;
    public UpgradesData upgradesData;
    public MissionsData missionsData;
    public CharactersData charactersData;
    public AchievementsData achievementsData;    
    public CharactersCollection charactersCollection;
    ValueKey<bool> hasData = new ValueKey<bool>("hasData_key", false);

    private void Awake()
    {
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        Initialize();
    }


    public void Initialize()
    {
        userData = new UserData();
        this.missionsData = new MissionsData();
        this.optionsData = new OptionsData();
        this.upgradesData = new UpgradesData();
        this.charactersData = new CharactersData(charactersCollection.characters.Count);
        this.achievementsData = new AchievementsData(AchievementsList.Instance.achievements.Count);
        this.LoadOrCreate(); 
    }

    
    public void ClearAll()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }


    public void LoadOrCreate()
    {
        if (!PlayerPrefUtils.HasKey(hasData.key))
        {
            PlayerPrefUtils.SetValue(true, ref hasData);
            this.userData.SetDefaults();
            this.missionsData.SetDefaults();
            this.optionsData.SetDefaults();
            this.upgradesData.SetDefaults();
            this.charactersData.SetDefaults();
        }
        else
        {
            this.userData.LoadData();
            this.missionsData.LoadData();
            this.optionsData.LoadData();
            this.upgradesData.LoadData();
            this.charactersData.LoadData();
        }
    }


    public void Reset()
    {
        this.userData.SetDefaults();
        this.optionsData.SetDefaults();
        this.missionsData.SetDefaults();
        this.upgradesData.SetDefaults();
        this.charactersData.SetDefaults();
    }


    public void SaveAll()
    {
        PlayerPrefs.Save();
    }

}
