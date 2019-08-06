using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionMan : MonoBehaviour
{
    public List<Mission> missions = new List<Mission>()
    {
        new EnterChimneyMission(5),
        new RedLightMission(3),
        new TouchWallMission(20),
        new DieBetweenMission(50,80),
        new LotCookieWithoutDieMission(1),
        new MetersWithoutDieMission(50),
        new CookieMission(50),
        new MeterMission(100),
        new CookieWithoutDieMission(10),
        new MetersWithoutDieMission(50),
        new BuyUpgradeMission(2),
        new LotCookieWithoutDieMission(1),
        new MeterMission(200),
        new CookieWithoutDieMission(10),
        new RedLightWithoutDieMission(5),
        new EnterChimneyMission(5),
        new LotCookieWithoutDieMission(10),
        new MetersWithoutDieMission(10),
        new BuyUpgradeMission(10),
        new RedLightMission(20),
        new MeterMission(100),
        new CookieWithoutDieMission(10),
    };

    public List<int> currentMisions;
    public static MissionMan Instance;
    bool showPopupAfterGame = false;

    public bool ShouldShowMissionAfterGamePopup
    {
        get
        {
            return showPopupAfterGame;
        }
        set
        {
            showPopupAfterGame = value;
        }
    }


    private void Awake()
    {
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        currentMisions = new List<int>();
        Initialize();
    }


    private void Start()
    {
        EventsMan.OnNewGameStart += OnNewGameStart;
    }

    void OnNewGameStart()
    {
        //this.showPopupAfterGame = false;
    }


    public void Initialize()
    {
        if (DataMan.Instance.missionsData.HasMissions)
        {
            LoadMissions();
        }
        else
        {
            DataMan.Instance.userData.PlayerLevel = 0;
            AddMissionsBylevel();
        }
    }

    void LoadMissions()
    {
        for (int i = 0; i < Constants.num_missions_per_level; i++)
        {
            currentMisions.Add(DataMan.Instance.missionsData.missions[i].IdMission);
            missions[currentMisions[i]].LoadMission(i, DataMan.Instance.missionsData.missions[i].IsMissionComplete);
        }        
    }


    public void AddMissionsBylevel()
    {
        int factor = DataMan.Instance.userData.PlayerLevel * 3;
        for (int i = 0; i < Constants.num_missions_per_level; i++)
        {
            currentMisions.Add(factor + i);
            missions[currentMisions[i]].OnAddMission();
            missions[currentMisions[i]].LoadMission(i, false);
            DataMan.Instance.missionsData.missions[i].IdMission = currentMisions[i];
            DataMan.Instance.missionsData.missions[i].IsMissionComplete = false;

        }

        DataMan.Instance.missionsData.HasMissions = true;
    }

    public string GetNameMissionById(int _idMission)
    {
        return missions[_idMission].GetString();
    }

    public void ReportCompleteMission(int idMission)
    {
        //FIX ME
        for (int i = 0; i < currentMisions.Count; i++)
        {
            if(currentMisions[i] == idMission)
            {
                DataMan.Instance.missionsData.missions[i].IsMissionComplete = true;
            }
        }

        this.showPopupAfterGame = true;
    }


    public Mission GetMissionByID(int i)
    {
        return missions[i];
    }

    public Mission GetMissionWithCurrentMissionsID(int i)
    {
        return missions[currentMisions[i]];
    }

    public bool AllMissionWasComplete()
    {
        bool res = true;
        for (int i = 0; i < currentMisions.Count; i++)
        {
            if (!GetMissionWithCurrentMissionsID(i).IsMissionComplete)
            {
                return false;
            }            
        }

        return res;
    }
    

    public void ClaimReward()
    {
        RewardMan.Instance.GetRewardMissions();
        this.currentMisions.Clear();
        int newlevel = DataMan.Instance.userData.PlayerLevel + 1;
        DataMan.Instance.userData.PlayerLevel = newlevel;
        AddMissionsBylevel();
    }







}
