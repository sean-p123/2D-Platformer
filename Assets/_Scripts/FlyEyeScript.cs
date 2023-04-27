using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEyeScript : MonoBehaviour
{
    public float speed = 3f;  // movement speed
    public float patrolDistance = 1.5f;  // distance to patrol along the y-axis
    public bool moveUp = true;  // whether the enemy should move up or down initially

    private float startY;  // starting y position
    private float currentY;  // current y position
    private int direction;  // 1 for up, -1 for down

    void Start()
    {
        startY = transform.position.y;
        currentY = startY;
        if (moveUp)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
     
    }

    void Update()
    {
        // move the enemy along the y-axis
        transform.Translate(0f, speed * direction * Time.deltaTime, 0f);
        currentY = transform.position.y;

        // check if the enemy has reached its patrol limit
        if (Mathf.Abs(currentY - startY) >= patrolDistance)
        {
            // reverse direction
            direction = -direction;
        }
    }
}
