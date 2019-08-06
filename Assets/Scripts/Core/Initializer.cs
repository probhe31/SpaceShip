using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    private void Awake()
    {

        StartCoroutine(LoadLanguage());
    }


    IEnumerator LoadLanguage()
    {
        LoadLocalization();
        while (!I18N.Instance.GetIsReady())
        {
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);
        Debug.Log("succesfull load language");

        yield return new WaitForSeconds(1.5f);
        ScreenMan.Instance.OpenScene(Screens.LoadingScreen);
    }

    public void LoadLocalization()
    {
        Debug.Log("default lang " + DataMan.Instance.optionsData.Language);
        I18N.Instance.LoadLanguage(Constants.languages_res[DataMan.Instance.optionsData.Language]);
    }
}
