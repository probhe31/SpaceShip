using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersData : ISaveable
{
    public List<CharacterData> characters;
    ValueKey<int> _current_skin = new ValueKey<int>("_current_skin", 0);


    public CharactersData(int countCharacters)
    {
        this.characters = new List<CharacterData>();

        for (int i = 0; i < countCharacters; i++)
        {
            characters.Add(new CharacterData(i));
        }
    }


    public int CurrentSkin
    {
        get
        {
            PlayerPrefUtils.LoadValue(ref _current_skin);
            return _current_skin.value;
        }
        set
        {
            PlayerPrefUtils.SetValue(value, ref _current_skin);
        }
    }


    public void LoadData()
    {
        PlayerPrefUtils.LoadValue(ref _current_skin);
        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].LoadData();
        }
    }

    public void SetDefaults()
    {
        PlayerPrefUtils.SetDefaultValue(ref _current_skin);

        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].SetDefaults();
        }
    }
}
