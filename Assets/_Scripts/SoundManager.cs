using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource btnClick;
    public AudioSource gameMusic;

    public static SoundManager instance = null;

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
    public void Start()
    {
        gameMusic.Play();
    }


    public void buttonClick()
    { 
        btnClick.Play();
    }
}
