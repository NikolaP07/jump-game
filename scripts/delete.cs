using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using System;
using UnityEngine.UI;


public class delete : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 direction;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject panel2;
    [SerializeField] private AudioSource Aus;

    float speed=3f;
   public  score_manager Score ;

    // Start is called before the first frame update
    private void Awake()
    {
        panel.SetActive(false);
        pausepanelOff();
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        
            if (Score.ScoreReturn())
            {
                speed += 0.5f;
            }
        
    
            transform.position += new Vector3(0, +speed*Time.deltaTime);
        
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.tag == "Player")
        {
            Aus.Play();
            gameOver();
        }

    }
    private void restart ()
    {
        SceneManager.LoadScene(2);
        timeGo();
    }
   public  void timeStop()
    {

        Time.timeScale = 0;
    }
    public void timeGo()
    {

        Time.timeScale = 1;
    }
  public  void startOver()
    {
        timeGo();
        restart();
    }
  public  void startScene()
    {
        SceneManager.LoadScene(0);

        timeGo();
    }
    public void pausepanelOn()
    {
        panel2.SetActive(true);
    }
    public void pausepanelOff()
    {
        panel2.SetActive(false);
    }
    public void gameOver()
    {

        timeStop();
        this.panel.SetActive(true);
    }

}
