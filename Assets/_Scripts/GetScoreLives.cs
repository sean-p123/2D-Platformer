using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetScoreLives : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text lifeLeft;

    private int lives;
    private int score;
   /* void update()
    {
      score =  LifeManager.instance.getScore();
      lives =  LifeManager.instance.GetCurrentLives();

        scoreText.text = score.ToString();
        lifeLeft.text = lifeLeft.ToString();
    }
    */
    private void Update()
    {
        score = LifeManager.instance.getScore();
        lives = LifeManager.instance.GetCurrentLives();

        scoreText.text = score.ToString();
        lifeLeft.text = lives.ToString();
    }
}
