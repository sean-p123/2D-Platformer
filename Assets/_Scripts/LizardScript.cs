using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardScript : MonoBehaviour
{
    public Animator animator;
    public GameObject fireBall;
    public Transform firePos;
    public Rigidbody2D f;


    private float timer;
    private float animateTimer;
    public float fireSpeed = 10f;
    [SerializeField] public float fireOffset = -1f;
    [SerializeField] int leftRight = -1;


    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Wait", false);
        //calls the shoot method
     //   StartCoroutine(shootFire());
    }

   /* IEnumerator shootFire()
    {
        //shoots fireball
        animator.SetBool("Wait", true);

        //waits for 3 seconds
        yield return new WaitForSeconds(3);
        Debug.Log("wait 3 secs");

        //calls the start method to repeat firing every 3 seconds
        Start(); 
    }
    */
    // Update is called once per frame
    void Update()
    {
        //adds time to timer
        timer += Time.deltaTime;
        
        //calls shoot every 3 seconds
        if(timer > 3)
        {

            // animator.SetBool("Wait", false);
            // timer = 0;
         //   Debug.Log("timer");
            shootFire();
        }
        
    }


    void shootFire()
    {
        //shoots fireball
        animator.SetBool("Wait", true);
      //  Debug.Log("wait 3 secs");

        //changes animation back to idle. 
        //allows shoot animation to finish it's animation
        animateTimer += Time.deltaTime;
        if (animateTimer > 0.5)
        {
            //shoot projectile here
            // calculate the position and direction for the fireball
            Vector2 firePosition = firePos.position + (firePos.right * fireOffset);
            Vector2 fireDirection = firePos.right * leftRight;

            //instansiate fireball and set it's speed and lifespan
            GameObject fire = Instantiate(fireBall, firePosition, Quaternion.identity);
            //scale the fireball by 5x
            fire.transform.localScale  *= 5;
            Rigidbody2D fireRigidbody = fire.GetComponent<Rigidbody2D>();
            fireRigidbody.velocity = fireDirection * fireSpeed;
            FireBallScript fireBS = fire.GetComponent<FireBallScript>();
            fireBS.lifespan = 2f;

            //    var fire = Instantiate(f, firePos.position, firePos.rotation);
            //    fire.AddForce(firePos.up * fireSpeed);


         //   Debug.Log("animate wait1");
            animator.SetBool("Wait", false);
            animateTimer = 0;
            timer = 0;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // check if the fireball collided with a barrier
        if (collision.gameObject.CompareTag("Barrier"))
        {
            // destroy the fireball object
            Destroy(gameObject);
        }
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("In collision method");

        if (collision.gameObject.tag == "Barrier")
        {
            Debug.Log("Collided with barrier");

            Destroy(this.gameObject);
        }

    }*/

}
