using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;
    [SerializeField] public int chooseScene;
    private void Awake()
    {
        // Check if an instance already exists
      /*  if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("Else : " + gameObject);
            Destroy(gameObject);
        }
        */
      
    }

    public void StartGame()
    {
        LifeManager.instance.setLife(3);
        SceneManager.LoadSceneAsync("FirstLevel");
    }

    public void whatScene(int scene)
    {

        Debug.Log("Whatscene: " + scene);
        if(scene == 1)
        {
            Debug.Log("sendtolevel 2");
            level2();
        }else if(scene == 2)
        {
            level3();
        }else if(scene == 3)
        {
            level3();
        }
        else if (scene == 6)
        {
            GameWon();
        }
    }
    public void level2()
    {
        SceneManager.LoadSceneAsync(1);
    }
    /*
    public void level2()
    {
        LifeManager.instance.resetHeart();
        SceneManager.LoadSceneAsync(chooseScene);
    }*/
    public void level3()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void GameWon()
    {
        SceneManager.LoadSceneAsync(6);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Tutorial()
    {
        SceneManager.LoadSceneAsync(7);
    }
    public void Menu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
