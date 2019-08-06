using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class I18N : MonoBehaviour
{
    private Dictionary<string, string> localizedText;
    private bool isReady = false;
    private string missingTextString = "Localized text not found";
    public string currentLanguage = "";
    public bool needUpdate = true;

    public static I18N Instance;
    private void Awake()
    {
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public void LoadLanguage(string language)
    {
        isReady = false;
        needUpdate = true;
        currentLanguage = language;

        string namefile = "localizedText_" + language;

        localizedText = new Dictionary<string, string>();

        TextAsset textasset = Resources.Load<TextAsset>(namefile);
        if (textasset!=null)
        {
            string dataAsJson = textasset.text;
            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

            for (int i = 0; i < loadedData.items.Length; i++)
            {
                localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
            }

            Debug.Log("Data loaded, dictionary contains: " + localizedText.Count + " entries.");
        }
        else
        {
            Debug.LogError("Cannot find file!");
        }

        isReady = true;
    }

    public string GetLocalizedValue(string key)
    {
        string result = missingTextString;
        if (localizedText.ContainsKey(key))
        {
            result = localizedText[key];
        }

        return result;

    }

    public bool GetIsReady()
    {
        return isReady;
    }

}