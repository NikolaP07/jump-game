using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int skinNr=0;
    public Sprite[] skins;
        SpriteRenderer spriterenderer;
  void Start()
    {
       skinNr= PlayerPrefs.GetInt("skinNr");
        spriterenderer = GetComponent<SpriteRenderer>();
        
    }
    void Update()
    {
        SkinChoise();
    }
    void SkinChoise()
    {

        spriterenderer.sprite = skins[skinNr];

    }
    public void SkinADD()
    {if (skinNr < skins.Length-1)
        {
            skinNr++;
            PlayerPrefs.SetInt("skinNr", skinNr);

           
        }
    }
    public void SkinDecrese()
    {
        if (skinNr > 0)
        {
            skinNr--;
            PlayerPrefs.SetInt("skinNr", skinNr);
        }

    }





}
