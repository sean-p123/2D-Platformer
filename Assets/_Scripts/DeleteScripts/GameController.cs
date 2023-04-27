using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public CameraFollowScript cfs;
    public static GameController instance = null;
    public int previousSceneIndex;

    public PlayerMovement player;
    private Vector3 playerStart;

    public Vector3 playerOriginalPosition;
    //   public RetryScript1 ShowRetryPanel;
    public UpdateScoreLife score;
    public GameObject retryPanel;
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

        playerStart = player.transform.position;

        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;

        retryPanel = GetComponent<GameObject>();

        /*retryPanel = GameObject.FindWithTag("Retry");
        if (retryPanel != null)
        {
            Debug.Log("setactive false");
            retryPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Retry panel is null!");
        }*/
    }

    // Unsubscribe from the sceneLoaded event when the object is destroyed
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // This method will be called every time a new scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // If the player object exists, reset its position
        if (player != null)
        {
            player.transform.position = playerStart;
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }

    public void HomeScreen()
    {
        SceneManager.LoadScene(0);
    }
    public void Died()
    {
        Debug.Log("died method");
        GameController.instance.previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("currentsceneindex: " + previousSceneIndex);

        retryPanel.SetActive(true);

       // score.UpdateScoreDisplay();
       // ShowRetryPanel.Setup();
       

    }

    public void Reload()
    {
       /* GameObject retryPanel = GameObject.Find("Retry");
        if (retryPanel != null)
        {
            retryPanel.SetActive(false);
        }*/

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Retry()
    {
        Debug.Log("Retry method");
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("active sceneindex: " + activeSceneIndex);
        //cfs.enabled = true;

        if (cfs != null)
        {
            cfs.enabled = true;
        }

            // Find the camera in the scene and enable the CameraFollowScript
            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                CameraFollowScript cameraFollowScript = mainCamera.GetComponent<CameraFollowScript>();
                if (cameraFollowScript != null)
                {
                    cameraFollowScript.enabled = true;
                }
            }
        
        SceneManager.LoadScene(1);
        

    }
}
