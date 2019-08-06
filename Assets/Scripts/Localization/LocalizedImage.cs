using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(LocalizedSpritesCollection))]
public class LocalizedImage : MonoBehaviour
{
    Image image;
    LocalizedSpritesCollection sprites;

    void Start()
    {
        image = GetComponent<Image>();
        sprites = GetComponent<LocalizedSpritesCollection>();
        UpdateValue();
    }

    public void UpdateValue()
    {
        if (image == null)
            image = GetComponent<Image>();

        image.sprite = sprites.GetLocalizedSprite();        
    }

    
}
