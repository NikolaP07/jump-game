using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class boost : MonoBehaviour
{
    [SerializeField] movemnt Move;
    [SerializeField] private AudioSource aud;

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
        if (collision.CompareTag("Player"))
        {
            aud.Play();
            int n = Random.Range(1, 11);
            if (n > 5)
            {
                Move.BoostJump();
            }else if(n<5)
            {
                Move.BoostSpeed();
            }
           
           
            Destroy(gameObject);
           

        }
    }
   

}
