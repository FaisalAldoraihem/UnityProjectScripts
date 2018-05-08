using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCon : MonoBehaviour {

    public GameObject[] hazzards;

    public Vector3 spawnvalue;

    public int hazzardcount, Score;

    public float SpawnWait, StartWait, waveWait, wave;
        
    public Text score, GameOverText,WaveCount,Gj;

    private bool GameOver, Restart,f;

    AudioSource A;

    public GameObject restartButton;

   

    void Start () {
        A = GetComponent<AudioSource>();
        restartButton.SetActive(false);
        //restart.text = "";
        GameOverText.text = "";
        Gj.text = "";
        GameOver = false;
        Restart = false;
        Score = 0; 
        UpdateScore();
        f = true;
        StartCoroutine(SpawnWaves());
        spawnP();

       }

    

    public void AddScore(int newScoreValue)
    {
        Score += newScoreValue;
        UpdateScore();
    }
     void Update()
    {
        UpdateWave();
        if (Restart)
        {
            if (Input.GetKeyDown(KeyCode.R)){
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(StartWait);
        while (f)
        {

            if (wave <= 10)
            {
                for (int i = 0; i < hazzardcount + wave; i++)
                {
                    GameObject hazzard = hazzards[Random.Range(0, hazzards.Length -1)];
                    
                    Vector3 spawnPos = new Vector3(Random.Range(-spawnvalue.x, spawnvalue.x), spawnvalue.y, spawnvalue.z);

                    Quaternion spawnRo = Quaternion.identity;

                    Instantiate(hazzard, spawnPos, spawnRo);

                    yield return new WaitForSeconds(SpawnWait);

                }
                yield return new WaitForSeconds(waveWait);
                wave++;
                
            }

            if (GameOver)
            {
                restartButton.SetActive(true);
                Restart = true;
                break;
            }

            if(wave > 10)
            {
                Gamecomplete();
                break;
            }


        }
        
            
    
    }
    void spawnP()
    {
        if(Random.Range(0.1f,1) >= 0.3)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnvalue.x, spawnvalue.x), spawnvalue.y, spawnvalue.z);

            Quaternion spawnRo = Quaternion.identity;

            Instantiate(hazzards[4], spawnPos, spawnRo);
        }
    }

    
	void UpdateScore () {
        score.text = "Score: " + Score;
	}

    public void Gameova()
    {
        GameOverText.text = "Game Ova";
        GameOver = true;
    }

    void UpdateWave()
    { 
        if(wave <= 10)
        {
            WaveCount.text = "Wave numba: " + wave;
        }
       
    }

    public void Gamecomplete()
    {
        Gj.text = "Go home and be a family man";
        
        Restart = true;
       
    }

    public void restartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
 


}
