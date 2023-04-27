using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public Animator animator;
    private float wait = 0f;
    [SerializeField] public int chooseScene;
    public bool isActive = false;
    public SceneLoader sl;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            nextLevel();
        }
    }

    private void Update()
    {
        if (!isActive) return;
        wait += Time.deltaTime;

        animator.SetBool("isTriggered", true);
        LifeManager.instance.resetHeart();
        Debug.Log("isTriggered portal time : " + wait);
        if (wait > 1f)
        {
        //    LifeManager.instance.resetHeart();
            sl.whatScene(chooseScene);
        }
    }

    private void nextLevel()
    {
        
    }
}
