using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LivesManager : MonoBehaviour
{
   // public int defaultLives = 3;
    public int livesCounter = 3;

    public TMP_Text livesText;
    public GameController gm;
    public DeathScript ds;
    public static LivesManager instance = null;
    
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
    
    // Start is called before the first frame update
    void Start()
    {
   //     livesCounter = defaultLives;
        livesText.text = ("x" + livesCounter.ToString());
    }

    public void Died()
    {
        livesCounter--;
        checkLife();
    }

    // Update is called once per frame
    void Update()
    {
        if (livesCounter < 1)
        {
            gm.GameOver();

        }
        else
        {
            livesText.text = ("x" + livesCounter);
        }
    }

    public void checkLife()
    {
        if(livesCounter > 1)
        {
            livesText.text = ("x" + livesCounter);
            Debug.Log("check life method");
            ds.enabled = false;
            gm.Died();
        }
    }

    public int livesLeft() {
        return livesCounter;
    }
}
