using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SpriteLanguage
{
    public string language;
    public Sprite sprite;
}

public class LocalizedSpritesCollection : MonoBehaviour
{
    public List<SpriteLanguage> sprites;

    public Sprite GetLocalizedSprite()
    {
        for (int i = 0; i < sprites.Count; i++)
        {
            if (sprites[i].language == I18N.Instance.currentLanguage)
            {
                return sprites[i].sprite;        
            }
        }

        return null;
    }
}
