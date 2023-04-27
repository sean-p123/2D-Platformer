using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneResetter : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.sceneLoaded += ResetScene;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= ResetScene;
    }

    private void ResetScene(Scene scene, LoadSceneMode mode)
    {
        transform.position = Vector3.zero; // Reset the player's position to (0, 0, 0)
        GetComponent<Rigidbody2D>().velocity = Vector2.zero; // Reset the player's velocity to (0, 0)
    }
}
