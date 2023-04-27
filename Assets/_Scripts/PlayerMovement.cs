using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Touch touch;
    private Vector2 touchStartPosition;
    private Vector2 touchEndPosition;
    private Vector2 touchPosition;

    private Vector2 direction;

    //serializeField allows to change these variables in unity inspector
    [SerializeField] float hSpeed = 10;
    [SerializeField] float vSpeed = 10;
    [SerializeField] float jumpSpeed = 10;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround; // check if the player is touching ground
    private bool isFalling = false; // check if the player is falling
    private float xPosition;
    private float yPosition;
    private float zPosition;

    //Ladder variables
    // The speed at which the player climbs the ladder
    public float climbingSpeed = 2f;

    // The input axis for climbing up and down the ladder
    public string climbAxis = "Vertical";

    // Whether the player is currently on a ladder
    private bool isClimbing = false;

    // The direction the player is moving on the ladder (up or down)
    private int climbingDirection = 0;


    public Rigidbody2D myRB;
    public Animator animator;
    public SpriteRenderer spi;
    public Transform playerTransform;

    public static PlayerMovement instance;
    public Vector3 playerOriginalPosition;
 /*   private void Awake()
    {
        // Check if an instance of the player already exists
        if (instance != null && instance != this)
        {
            // Destroy this object if an instance already exists
            Destroy(gameObject);
        }
        else
        {
            // Set this object as the singleton instance
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
   */ 

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
        playerOriginalPosition = playerTransform.position;
    }

    Vector3 getStartPosition()
    {
        return playerOriginalPosition;
    }
    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

     //   movementInput = movement.action.ReadValue<Vector2>();
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        float xOffset = hInput * hSpeed * Time.deltaTime;
        float yOffset = vInput * vSpeed * Time.deltaTime;

        //multiply by time.deltatime to ensure this happens on each frame to run smooth
        xPosition = transform.position.x + xOffset;
        yPosition = transform.position.y + yOffset;

        animator.SetFloat("Speed", Mathf.Abs(xOffset));

        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
        transform.position = new Vector3(xPosition, yPosition, transform.position.z);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spi.flipX = true;

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            spi.flipX = false;

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
           // Vector2 jumpVelToAdd = new Vector2(0f, jumpSpeed);
            //myRB.velocity += jumpVelToAdd;s
         //   animator.SetFloat("Jump", Mathf.Abs(jumpSpeed));
        }
        if ((Input.GetButtonDown("Jump") && isTouchingGround) || (Input.GetButtonDown("Jump") && myRB.velocity.y ==0) ){
            myRB.velocity = new Vector2(myRB.velocity.x, jumpSpeed);
            animator.SetBool("isJumping", true);
        }
    /*    if(isTouchingGround == false)
        {
            animator.SetBool("isJumping", false);
        }*/
        if (myRB.velocity.y < 0f )// && !isTouchingGround)// && !isFalling)
        {
            animator.SetBool("isJumping", false);
            isFalling = true;
            animator.SetBool("isFalling", true);
        }

        if (isTouchingGround || myRB.velocity.y == 0)
        {
          //  animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }
        
        

        //ladder movement
        if (isClimbing)
        {
            // Move the player up or down the ladder
            transform.Translate(Vector3.up * climbingDirection * climbingSpeed * Time.deltaTime);
            animator.SetBool("isClimbing", true);
            // Check if the player has reached the top or bottom of the ladder
           /* if (!Input.GetButton(climbAxis))
            {
                animator.SetBool("isClimbing", false);
                isClimbing = false;
            }*/

        }
        else
        {
            animator.SetBool("isClimbing", false);
            isClimbing = false;
        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Check if the player collides with a ladder
        if (collision.gameObject.tag == "Ladder")
        {
            // Check if the player presses the climb up or down button
            float climbInput = Input.GetAxisRaw(climbAxis);
            if (climbInput != 0)
            {
                // Set the climbing direction and start climbing
                climbingDirection = (int)climbInput;
                isClimbing = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Reset the climbing direction and stop climbing
        climbingDirection = 0;
        isClimbing = false;
    }

    public void moveHorizontally(float direction)
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        float xOffset = hInput * hSpeed * Time.deltaTime;
        float yOffset = vInput * vSpeed * Time.deltaTime;

        //multiply by time.deltatime to ensure this happens on each frame to run smooth
        xPosition = transform.position.x + xOffset;
        yPosition = transform.position.y + yOffset;

        animator.SetFloat("Speed", Mathf.Abs(xOffset));

        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
        transform.position = new Vector3(xPosition, yPosition, transform.position.z);


    }


    public void playerHit()
    {
        animator.SetBool("isHit", true);
     //   zPosition = transform.position.z - 0.1f;
     //   transform.position = new Vector3(xPosition, yPosition, zPosition);
       
    }
   
}
