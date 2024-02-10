using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.Tilemaps;

public class pesedualGeneration : MonoBehaviour
{
  
    private int width=6;
    private int height = 30;
    public Tilemap tilemap;
    public RuleTile dirt;
    private int start=0;
    private int  i=0;
    public functiontimer timer;
    [SerializeField] public GameObject enemy;
    [SerializeField] public GameObject Buff;
    public  score_manager Score ; 

    public int visinPlatforme =5;
    public float Timer=7f;
    





   
    // Start is called before the first frame update
    void Start()
    {
       Generation();



       functiontimer.Create(Generation,2f);
     
    }
  

    // Update is called once per frame

    void Update()
    {
        
   
        Timer -= Time.deltaTime;
        if(Timer<0)
        {
            Generation();
            Timer = 6f;
        }
      
             
    }
 public  void Generation()
    {
          

        for (i = 0; i < 30; i++)
        {
            SpawnPlatform(6,start);
            SpawnPlatform(-6, start);
            int randNUm = Random.Range(0, 11);


            if (randNUm > 5 && i%5==0)
            {
                platform();
            }else if (randNUm < 5 && i % 5 == 0)
            {
                negativplatform();
            }
            height++;
            start++;
        
        }
   

    }
   private  void platform()
    {
        int i,m;

        int n = Random.Range(3, 6);
        m = Random.Range(3, 6);
        for (i = 0; i < n; i++)
        {
            SpawnPlatform(width - i, height);
           
            if( i==m)
            {
                n = Random.Range(1, 10);
                if(n>5)
                {
                    Spawn(width - i, height + 1);
                }
                else if (n<5)
               {
                    SpawnBuff(width - i, height + 1);
               
                }

            }
        }
       

    }
    private void negativplatform()
    {
        int i,m;
        int max = 10;
        

            if (Score.ScoreReturn())
            {

                max -= 1;
            }
        

        int n = Random.Range(3, 6);
        m = Random.Range(3, 6);
        for (i = -n; i < 0; i++)
        {
            SpawnPlatform(-width - i, height);
            if (i == m)
            {
                n = Random.Range(1, max);
                if (n > 5)
                {
                    Spawn(-width - i, height + 2);
                }
                else if (n < 5)
                {
                    SpawnBuff(-width - i, height + 2);

                }

            }
        }


    }
    private void SpawnPlatform(int x,int y)
    {
        tilemap.SetTile(new Vector3Int(x, y, 0), dirt);
    }
    private void Spawn(int x,int y)
    {
        Vector3 pos = new Vector3(x, y,0);
        Instantiate(enemy, pos,Quaternion.identity);

    }
    private void SpawnBuff(int x, int y)
    {
        Vector3 pos = new Vector3(x, y, 0);
        Instantiate(Buff, pos, Quaternion.identity);
    }
}
