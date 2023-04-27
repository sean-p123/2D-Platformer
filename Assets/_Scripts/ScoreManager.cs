using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TMP_Text scoreText;
    private int score = 0;

    private void Awake()
    {
        /*
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        */
        /* if (instance == null)
         {
             instance = this;
         }
         else if (instance != this)
         {
             Destroy(gameObject);
         }*/
    }
    private void Start()
    {
        scoreText.text = "Score : " + score.ToString();
    }

    public void ChangeScore(int scoreValue)
    {
        score += scoreValue;
        scoreText.text = "Score : " + score.ToString();
    }
    public int getScore()
    {
        return score;
    }
}
