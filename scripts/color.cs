using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class color : MonoBehaviour
{
    // Start is called before the first frame update
         SpriteRenderer ren;
    [SerializeField] Slider slider1;
    [SerializeField] Slider slider2;
    [SerializeField] Slider slider3;
    Color NewColor;

    private void Start()
    {
     

        ren = GetComponent<SpriteRenderer>();
         slider1.value = PlayerPrefs.GetFloat("slider1");
            slider2.value = PlayerPrefs.GetFloat("slider2");
            slider3.value = PlayerPrefs.GetFloat("slider3");
            ren.color = new Color(slider1.value, slider2.value, slider3.value);
        

    }
    private void Update()
    {
     
        ren.color = new Color(slider1.value, slider2.value, slider3.value);
        PlayerPrefs.SetFloat("slider1", slider1.value);
        PlayerPrefs.SetFloat("slider2", slider2.value);
        PlayerPrefs.SetFloat("slider3", slider3.value);

        

    }
    

}
