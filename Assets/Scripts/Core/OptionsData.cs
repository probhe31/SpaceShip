using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsData
{
    ValueKey<bool> _isFullScreen = new ValueKey<bool>("options_isFullScreen_key", false);
    ValueKey<int> _scale = new ValueKey<int>("options_scale_key", 1);
    ValueKey<int> _language = new ValueKey<int>("options_language_key", 1);
    ValueKey<int> _sfxVolume = new ValueKey<int>("options_sfxVolume_key", 5);
    ValueKey<int> _musicVolume = new ValueKey<int>("options_musicVolume_key", 5);
   
    public bool IsFullScreen
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _isFullScreen);
            return _isFullScreen.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _isFullScreen);
        }
    }

    public int Scale
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _scale);
            return _scale.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _scale);
        }
    }

    public int Language
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _language);
            return _language.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _language);
        }
    }

    public int SfxVolume
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _sfxVolume);
            return _sfxVolume.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _sfxVolume);
        }
    }

    public int MusicVolume
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _musicVolume);
            return _musicVolume.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _musicVolume);
        }
    }


    public void LoadData()
    {
        PlayerPrefUtils.LoadValue(ref _isFullScreen);
        PlayerPrefUtils.LoadValue(ref _scale);
        PlayerPrefUtils.LoadValue(ref _language);
        PlayerPrefUtils.LoadValue(ref _sfxVolume);
        PlayerPrefUtils.LoadValue(ref _musicVolume);
    }

    public void SetDefaults()
    {
        PlayerPrefUtils.SetDefaultValue(ref _isFullScreen);
        PlayerPrefUtils.SetDefaultValue(ref _scale);
        PlayerPrefUtils.SetDefaultValue(ref _language);
        PlayerPrefUtils.SetDefaultValue(ref _sfxVolume);
        PlayerPrefUtils.SetDefaultValue(ref _musicVolume);
    }

}
