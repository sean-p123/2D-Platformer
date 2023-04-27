using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateScoreLife : MonoBehaviour
{
    private ScoreManager scoreManager;
    private LivesManager lifeManager;
    public TMP_Text scoreText;

    void Start()
    {
        scoreManager = ScoreManager.instance;
     //   scoreText = GetComponent<TMP_Text>();
        UpdateScoreDisplay();
    }

    public void UpdateScoreDisplay()
    {
        int score = scoreManager.getScore();
        scoreText.text = "Score : " + score.ToString();
    }
}
