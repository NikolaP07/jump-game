using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_manager : MonoBehaviour
{
    [SerializeField] private Transform traker;
    public Text scoreText;
    public Text highscoreText;
    public int score=0 ;
    public float highty=0;
    int hightscore=0;
    private int SavedScore = 1000;
    
  
   
    // Start is called before the first frame update
    void Start()
    {
        hightscore = PlayerPrefs.GetInt("HUGHSCORE");
        scoreText.text = score.ToString() +  " points";
        highscoreText.text = "HIGHSCORE: " + hightscore.ToString();
    }
   

    // Update is called once per frame
    void Update()
    {
        
        
        if(highty<traker.position.y)
        {

            highty = traker.position.y;
            score++;
            scoreText.text = score.ToString() + " points";
            if(score>hightscore)
            {
                hightscore = score;
                highscoreText.text = "HIGHSCORE: " + hightscore.ToString();
                PlayerPrefs.SetInt("HUGHSCORE", hightscore);
            }

        }
    }
    public bool ScoreReturn()
    {
        if(this.SavedScore<this.score)
        {
            this.SavedScore += 1000;
            return true;
        }
        return false;


    }
}
