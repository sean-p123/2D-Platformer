using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryLvl1 : MonoBehaviour
{
    private string nextScene;
    public void Retry()
    {
        LifeManager.instance.score = 0;
        nextScene = LifeManager.instance.getSceneName();
        Debug.Log("retrylvl1");
        SceneManager.LoadScene(nextScene);
    }

    public void mainMenu()
    {
        LifeManager.instance.setLife(0);
        LifeManager.instance.setScore(0);
        SceneManager.LoadSceneAsync("HomeScreen");
    }

    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
