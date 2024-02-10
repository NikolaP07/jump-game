using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class enemy : MonoBehaviour
{

   [SerializeField]private delete deleter;
        void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (collision.gameObject.tag == "Player")
        {

            deleter.gameOver();
        }
    }
}
