using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class functiontimer
{    public static functiontimer Create(Action action,float timer)
    {
        functiontimer Funciontimer = new functiontimer(action,timer);
        
        GameObject gameObject = new GameObject("functiontimer",typeof(MonoBehaviourHook));
        gameObject.GetComponent<MonoBehaviourHook>().onUpdate = Funciontimer.Update;
    return Funciontimer;
    }
 private  class MonoBehaviourHook: MonoBehaviour
    {
        public Action onUpdate;
        private void Update()
        {
            if(onUpdate != null)
            { onUpdate();}
        }
    }
    private Action action;
    private float timer;
    public bool isDestroyed;

    public functiontimer(Action action,float timer)
    {
        this.action=action;
        this.timer=timer;
         isDestroyed=false;

    }
    public void Update()
    {
        if(!isDestroyed)
        {
        timer-=Time.deltaTime;
        if(timer<0)
        {
            action();
            DestroySelf();
        }
        }
    }
    private void DestroySelf()
    {
          isDestroyed=true;
    }
    
}
