using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageOptionButton : OptionButton, ILoadableData
{
    public Text languageTxt;
    int c = 0;
    public List<LocalizedText> localizeds;

    public void LoadData()
    {
        c = DataMan.Instance.optionsData.Language;
        SetLanguageText(c);

        Debug.Log("loading language configuration _ current language" + c);

    }

    public override void OnClick()
    {
        c++;
        if(c > Constants.languages.Length-1)
        {
            c = 0;
        }
        SetLanguageText(c);
        DataMan.Instance.optionsData.Language = c;
        I18N.Instance.LoadLanguage(Constants.languages_res[c]);

        for (int i = 0; i < localizeds.Count; i++)
        {
            localizeds[i].UpdateValue();
        }
    }

    void SetLanguageText(int idLanguage)
    {
        languageTxt.text = Constants.languages[c].ToUpper();
    }
}