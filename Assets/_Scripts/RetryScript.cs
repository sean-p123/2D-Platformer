using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RetryScript : MonoBehaviour
{
    public TMP_Text scoreText;

    public static RetryScript instance;


   
    public void Setup(int score)
    {
        //gameObject.SetActive(true);
        this.gameObject.SetActive(true);
        Debug.Log("setactive");
        scoreText.text = "Score : " + score.ToString();
    }

    public void Restart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int currentSceneIndex = currentScene.buildIndex;
        Debug.Log("Active scene: " + currentScene.name);
       // gameObject.SetActive(false);
        SceneManager.LoadScene(currentSceneIndex);
        gameObject.SetActive(false);
    }

    private void Awake()
    {
     //   gameObject.SetActive(true);
        gameObject.SetActive(false);
    //    instance.gameObject.SetActive(true);
    //    instance.gameObject.SetActive(false);
        //  DontDestroyOnLoad(gameObject);
    }
}
