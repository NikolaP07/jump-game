using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeinMenu : MonoBehaviour
{
    
   
    public void PlayGame()
    {
      
       
        SceneManager.LoadScene(thisScene());
    }
    public void PlayGameEnd()
    {
        Application.Quit();
    }
    public int thisScene()
       
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex +1);
       
        return SceneManager.GetActiveScene().buildIndex +1;
    }
}
