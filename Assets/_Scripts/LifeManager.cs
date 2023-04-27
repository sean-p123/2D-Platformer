using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    public int startingLives = 3;
    public int currentLives;

    public TMP_Text scoreText;
    public TMP_Text lifeLeft;

    public int score = 0;
    private int scoreValue = 10;
    public int currentSceneIndex = 1;
    public RetryScript retry;

    public string sceneName;
    private int timesEntered = 0;

    private bool heartCollected = false;
    private bool coinCollected = false;
    private List<string> collectedCoins = new List<string> { };


    // Singleton instance
    public static LifeManager instance;

    private void Awake()
    {
        // Check if an instance already exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

     /*   scoreText.text = "Score : " + score.ToString();
        lifeLeft.text = "x" + currentLives.ToString();
        currentLives = startingLives;
        */
    }
    
   
    /*
    private void Start()
    {
   //     currentLives = startingLives;
        scoreText.text = "Score : " + score.ToString();
        lifeLeft.text = "x" + currentLives.ToString();
    }
    */

    //code for the score functionality
    public void ChangeScore(GameObject coin)
    {
        Destroy(coin);
      //  hasCoinBeenCollected();
     //   coinCollected = true;
        score += scoreValue;

        saveCoin(coin);

        coin.SetActive(false);
   //     scoreText.text = "Score : " + score.ToString();
    }

    public void setScore(int newScore)
    {
        score = newScore;
    }
    public int getScore()
    {
        return score;
    }

    public bool hasCoinBeenCollected(GameObject checkCoin)
    {
        foreach(string coin in collectedCoins)
        {
            if(checkCoin.name == coin)
            {
                coinCollected = true;
            }
        }

        return coinCollected;
    }

    void saveCoin(GameObject coin)
    {
        collectedCoins.Add(coin.name);

     
    }

    public string getSceneName()
    {
        
        Debug.Log("Scene name: "+sceneName);
            return sceneName;
    }

//code for the life functionality

        public void setLife(int newLife)
    {
        currentLives = newLife;
    }
        public void LoseLife(int lost)
    {
        sceneName = SceneManager.GetActiveScene().name;
        Debug.Log("Lives left1: " + currentLives);
        Debug.Log("times entered1: " + timesEntered);
        
            Debug.Log("Lose 1 Life");
            timesEntered++;
            currentLives-=lost;
            changeLifeValue(currentLives);
            if (currentLives <= 0)
            {
                Debug.Log("times entered1: " + timesEntered);
                Debug.Log("Lives left2: " + currentLives);
                GameOver();
            }
            else
            {
                Debug.Log("Lives left: " + currentLives);
                Debug.Log("times entered2: " + timesEntered);
                changeLifeValue(currentLives);
                TryAgain();
                  /*   retry.enabled = true;
                     retry.gameObject.SetActive(true); // enable the RetryScript object
                Debug.Log("SetupScore");
                retry.Setup(score);
                */
                /*  if (retry != null)
                  {
                      retry.Setup(score);
                  }*/
                // retry.Setup(score);
                // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        
            
        }

    public void addLife(GameObject heart)
    {
        if (!heart.activeSelf) // Check if the heart has already been collected
        {
            return;
        }

      //heart.SetActive(false); // Deactivate the heart so it can't be collected again
        Destroy(heart);
        //  DestroyImmediate(heart
        heartCollected = true;

        currentLives++;
        changeLifeValue(currentLives);

        /* Destroy(heart);
         currentLives++;*/
    }

    public bool HasHeartBeenCollected() {

        if (heartCollected)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
    private void TryAgain()
    {
        SceneManager.LoadScene("Retry");
    }
    private void GameOver()
    {
        // Load game over scene or do something else
        Debug.Log("Game Over");
        SceneManager.LoadScene("GameOver");
    }
    //resets hearts when enter new level
    public void resetHeart()
    {
        heartCollected = false;
    }
    public int GetCurrentLives()
    {
        return currentLives;
    }

    public void changeLifeValue(int livesLeft)
    {
      //  lifeLeft.text = "x" + livesLeft.ToString();
    }

    

    public void Retry()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void clearUI()
    {

    }
}
