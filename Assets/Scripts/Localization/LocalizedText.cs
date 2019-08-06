using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizedText : MonoBehaviour
{

    public string key;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();

        UpdateValue();
    }

    public void UpdateValue()
    {
        if (text == null)
            text = GetComponent<Text>();

        text.text = I18N.Instance.GetLocalizedValue(key);
    }

    public void SetValue(string t)
    {
        text = GetComponent<Text>();
        this.key = t;
        UpdateValue();
    }
}

