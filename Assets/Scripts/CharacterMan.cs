using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMan : MonoBehaviour
{
    public CharactersCollection charactersCollection;
    public static CharacterMan Instance;

    private void Awake()
    {
        Instance = this;
        LoadCharactersData();
        EventsMan.OnNewGameStart += OnNewGameStart;
        GameObject.DontDestroyOnLoad(this.gameObject);

    }

    public void OnNewGameStart()
    {
    }

    public void LoadCharactersData()
    {
    }

    public bool OnBuyCharacter(int characterID)
    {
        if (EconomyMan.Instance.Buy(
            charactersCollection.characters[characterID].price))
        {
            DataMan.Instance.charactersData.characters[characterID].Status = CharacterState.Bought;
            return true;
        }

        return false;
    }

    public void OnEquipCharacter(int characterID)
    {
        //Debug.Log("characters " + characterID);
        DataMan.Instance.charactersData.CurrentSkin = characterID;
        DataMan.Instance.SaveAll();
    }


    public int GetStatusByID(int idU)
    {
        return DataMan.Instance.charactersData.characters[idU].Status;
    }

}
