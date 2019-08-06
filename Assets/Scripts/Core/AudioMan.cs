using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMan : MonoBehaviour
{
    
    int musicVolume;
    int soundsVolume;

    public static AudioMan Instance;
    private void Awake()
    {
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    

    public void SetMusicVolume(int volume)
    {
        this.musicVolume = volume;
        DataMan.Instance.optionsData.MusicVolume = this.musicVolume;
    }

    public void SetSoundsVolume(int volume)
    {
        this.soundsVolume = volume;
        DataMan.Instance.optionsData.SfxVolume = this.soundsVolume;
    }

    public void SetMusicVolumeScale(int vol, int max)
    {
        
        this.musicVolume = vol / max;
        DataMan.Instance.optionsData.MusicVolume = vol;
    }

    public void SetSoundsVolumeScale(int vol, int max)
    {
        this.soundsVolume = vol / max;
        DataMan.Instance.optionsData.SfxVolume = vol;
    }


}
