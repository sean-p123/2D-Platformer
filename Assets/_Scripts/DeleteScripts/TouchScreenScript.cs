using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScreenScript : MonoBehaviour
{
    public PlayerMovement player;
    private Touch touch;
    private Vector2 touchStartPosition;
    private Vector2 touchEndPosition;
    private Vector2 touchPosition;

    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPosition = touch.position;
                    break;
                case TouchPhase.Moved:
                    direction = touch.position - touchStartPosition;
                    Debug.Log("Moving X: " + direction.x);
                    player.moveHorizontally(direction.x);
                    //   player.mov(direction.x);
                    break;
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Ended:
                    touchEndPosition = touch.position;
                    break;
                case TouchPhase.Canceled:
                    break;
                default:
                    break;
            }
            if (touchStartPosition == touchEndPosition)
            {
                print("tap recognised");
            }
        }
    }
}
