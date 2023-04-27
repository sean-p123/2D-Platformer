using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonScript : MonoBehaviour
{
    public float speed = 2f;        // speed at which the skeleton moves
   [SerializeField] public float leftBound = 50f;   // left boundary of the patrol area
   [SerializeField] public float rightBound = 60f;   // right boundary of the patrol area

    private bool movingRight = true;    // flag to keep track of direction
    public Animator animator;

    private void Start()
    {
        transform.localScale = new Vector2(7f, 7f);
        animator.SetBool("isWalking", true);
    }
   
    void Update()
    {
        // move the skeleton
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            // check if the skeleton has reached the right boundary
            if (transform.position.x >= rightBound)
            {
                // turn the skeleton around and set the flag
                transform.localScale = new Vector2(-7f, 7f);
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            // check if the skeleton has reached the left boundary
            if (transform.position.x <= leftBound)
            {
                // turn the skeleton around and set the flag
                transform.localScale = new Vector2(7f, 7f);
                movingRight = true;
            }
        }
    }
}
