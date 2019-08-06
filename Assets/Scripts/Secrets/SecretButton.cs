using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SecretButton : MonoBehaviour
{
    public int idSecretButton = 0;
    Button button;

    void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(OnFoundSecretButton);
    }

    public void OnFoundSecretButton()
    {
        if(idSecretButton>=0 && idSecretButton< DataMan.Instance.achievementsData.secrets.Count)
        {
            DataMan.Instance.achievementsData.secrets[idSecretButton].WasFound = true;
            EventsMan.Instance.Call_OnFoundSecretButton();
        }

    }

}
