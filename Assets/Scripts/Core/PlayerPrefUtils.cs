using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefUtils  {

    public static bool HasKey(string key)
    {
        return PlayerPrefs.HasKey(key);        
    }

    public static void LoadValue(ref ValueKey<int> valueKey)
    {
        int val = PlayerPrefs.GetInt(valueKey.key);
        valueKey.value = val;        
    }

    public static void LoadValue(ref ValueKey<bool> valueKey)
    {
        bool val = PlayerPrefs.GetInt(valueKey.key) == 0 ? false : true;
        valueKey.value = val;
    }

    public static void LoadValue(ref ValueKey<float> valueKey)
    {
        float val = PlayerPrefs.GetFloat(valueKey.key);
        valueKey.value = val;
    }

    public static void LoadValue(ref ValueKey<string> valueKey)
    {
        string val = PlayerPrefs.GetString(valueKey.key);
        valueKey.value = val;
    }

    //--------------------------------------------------------------------------

    public static void SetValue(int val, ref ValueKey<int> valueKey)
    {
        valueKey.value = val;
        PlayerPrefs.SetInt(valueKey.key, valueKey.value);
    }

    public static void SetValue(bool val, ref ValueKey<bool> valueKey)
    {
        valueKey.value = val;
        PlayerPrefs.SetInt(valueKey.key, valueKey.value?1:0);
    }

    public static void SetValue(float val, ref ValueKey<float> valueKey)
    {
        valueKey.value = val;
        PlayerPrefs.SetFloat(valueKey.key, valueKey.value);
    }

    public static void SetValue(string val, ref ValueKey<string> valueKey)
    {
        valueKey.value = val;
        PlayerPrefs.SetString(valueKey.key, valueKey.value);
    }

    public static void SetDefaultValue(ref ValueKey<int> valueKey)
    {
        valueKey.value = valueKey.defaultValue;
        PlayerPrefs.SetInt(valueKey.key, valueKey.value);
    }

    public static void SetDefaultValue(ref ValueKey<bool> valueKey)
    {
        valueKey.value = valueKey.defaultValue;
        PlayerPrefs.SetInt(valueKey.key, valueKey.value ? 1 : 0);
    }

    public static void SetDefaultValue(ref ValueKey<float> valueKey)
    {
        valueKey.value = valueKey.defaultValue;
        PlayerPrefs.SetFloat(valueKey.key, valueKey.value);
    }

    public static void SetDefaultValue(ref ValueKey<string> valueKey)
    {
        valueKey.value = valueKey.defaultValue;
        PlayerPrefs.SetString(valueKey.key, valueKey.value);
    }
}
