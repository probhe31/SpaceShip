using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicOptionButton : OptionButton, ILoadableData
{
    int value = 0;
    public List<Image> bars;

    public void LoadData()
    {
        value = DataMan.Instance.optionsData.MusicVolume;
        UpdateBars();
    }

    void UpdateBars()
    {
        for (int i = 0; i < bars.Count; i++)
        {
            bars[i].gameObject.SetActive(i < value);
        }
    }

    public override void OnClick()
    {
        value++;
        if (value > bars.Count)
        {
            value = 0;
        }

        AudioMan.Instance.SetMusicVolumeScale(value, bars.Count);
        UpdateBars();
    }
}