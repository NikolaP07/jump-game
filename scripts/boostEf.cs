using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class boostEf : MonoBehaviour
{
    [SerializeField] movemnt Move;
    [SerializeField] GameObject  SLIDER;
    functiontimer timer;
    public Slider Slider;
    float Timer;
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer > 0)
        {

            Timer -= Time.deltaTime;
            if(Timer<=0)
            {
                SLIDER.SetActive(false);
            }

        }

    }
    public void SetMaxValue(float value)
    {
        Slider.maxValue = 5;

    }
    public void SetValue(float value)
    {
        Slider.value = Timer;

    }
    public void  timerStart()
    {
        Timer = 5;
        SLIDER.SetActive(true);
        Move.BoostSpeed();
        
        
    }
}
