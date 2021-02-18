using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public Text scoreText;
    public Text BestscoreText;
    public int score;
    int bestRezult;

    public GameObject panelPause;
    public bool pauseActive;
    private void Awake()
    {
        Gamemanager[] gameManagers = FindObjectsOfType<Gamemanager>();
        for (int i = 0; i < gameManagers.Length; i++)
        {
            if (gameManagers[i].gameObject != gameObject)
            {
                Destroy(gameObject);
                break;
            }

        }
       
        bestRezult = PlayerPrefs.GetInt("BestScor");
        print(bestRezult);
        //BestscoreText.text = PlayerPrefs.GetInt("BestScor").ToString();
    }


    private void Update()
    {
        BestscoreText.text = bestRezult.ToString();
        scoreText.text = score.ToString();
        DontDestroyOnLoad(gameObject);


        


        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (pauseActive)
            {
                panelPause.active = false;
                Time.timeScale = 1f;
                pauseActive = false;
            }
            else
            {
                panelPause.active = true;
                Time.timeScale = 0f;
                pauseActive = true;
            }
        }
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        scoreText.text = score.ToString();
        if (bestRezult < score)
        {
            PlayerPrefs.SetInt("BestScor", score);
        }
    }
    public void BestScore()
    {
      
    }

}
