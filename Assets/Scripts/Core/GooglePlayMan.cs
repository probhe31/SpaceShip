using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GooglePlayMan : MonoBehaviour
{
    public static GooglePlayMan Instance;
    private void Awake()
    {
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public void Login()
    {
        Social.localUser.Authenticate((bool success) => {
            if (success)
            {
                Debug.Log("LOGEADO");
            }
            else
            {
                Debug.Log("bad");
            }
        });
    }

    public void UpdateAchievement()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress("CgkI6eThxd8HEAIQAQ", 5.0f, (bool success) => {
                if (success)
                {
                    Debug.Log("cool");
                }
                else
                {
                    Debug.Log("bad");
                }

            });
        }


    }

}
