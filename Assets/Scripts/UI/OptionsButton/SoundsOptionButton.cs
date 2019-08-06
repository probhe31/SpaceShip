using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundsOptionButton : OptionButton, ILoadableData
{
    int value = 0;
    public List<Image> bars;

    public void LoadData()
    {
        value = DataMan.Instance.optionsData.SfxVolume;
        UpdateBars();
    }

    void UpdateBars()
    {
        for (int i = 0; i < bars.Count; i++)
        {
            bars[i].gameObject.SetActive(i<value);
        }
    }

    public override void OnClick()
    {
        value++;
        if (value > bars.Count)
        {
            value = 0;
        }

        AudioMan.Instance.SetSoundsVolumeScale(value, bars.Count);
        UpdateBars();
    }
}