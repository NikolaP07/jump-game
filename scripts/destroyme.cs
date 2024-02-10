using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class destroyme : MonoBehaviour
{ 


    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        

   
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="delete")
        {
            Debug.Log("hit of deletion");
            Destroy(gameObject);
        }
       
    }

}
