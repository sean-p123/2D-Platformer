using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerMovement player;
    private Vector2 playerStart;

    public GameObject winScreen;
    public GameObject gameOverScreen;

    public static GameManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        
    }

     public void GameStart()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

   
/*
 * 
 * 
    // Start is called before the first frame update
    public void Start()
    {
        playerStart = player.transform.position;
    }
    
    public void winLevel()
    {
        winScreen.SetActive(true);
        player.gameObject.SetActive(false);

    }
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
    public void restart()
    {
        winScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        player.gameObject.SetActive(true);
        player.transform.position = playerStart;
    }
    */
}
