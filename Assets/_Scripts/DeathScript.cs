using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    private float DeathScreen = 0f;
    private bool hasExecuted = false;
    // public LivesManager lm;
   // public LifeManager life;
    public SpriteRenderer spriteRenderer;
   // public Sprite deadSprite;
    public Animator animator;

    private void Reset()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
    /*    DeathScreen += Time.deltaTime;
       // Debug.Log("DS enabled");
        if (DeathScreen > 1f && !hasExecuted)
        {
            hasExecuted = true;
            Debug.Log("DS timer");
        //    lm.Died();

        }*/
        if (gameObject.transform.position.y < -10 && !hasExecuted)
        {
            Debug.Log("Set active false");
            gameObject.SetActive(false);
            Debug.Log("Set active false1");
            // life.LoseLife(1);
            LifeManager.instance.LoseLife(1);
            hasExecuted = true;
        }
    }

    private void OnEnable()
    {
       
        Debug.Log("DS enabled1");
        UpdateSprite();
        DisablePhysics();
        StartCoroutine(Animate());
        
    }

    private void OnDisable()
{
    // Reset DeathScreen timer
    DeathScreen = 0f;
    hasExecuted = false;

    // Reset sprite
    spriteRenderer.enabled = true;
    animator.SetBool("isHit", false);

    // Enable physics and movement
    Collider2D[] colliders = GetComponents<Collider2D>();

    foreach (Collider2D collider in colliders)
    {
        collider.enabled = true;
    }

    GetComponent<Rigidbody2D>().isKinematic = false;
    GetComponent<PlayerMovement>().enabled = true;
}
    
        private void UpdateSprite()
    {
        spriteRenderer.enabled = true;
        spriteRenderer.sortingOrder = 10;

        animator.SetBool("isHit", true);
        /* if (deadSprite != null)
         {
           //  spriteRenderer.sprite = deadSprite;
             animator.SetBool("isHit", true);
         }*/
    }
    private void DisablePhysics()
    {
        Collider2D[] colliders = GetComponents<Collider2D>();

        foreach (Collider2D collider in colliders)
        {
            collider.enabled = false;
        }

        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;


    }
    private IEnumerator Animate()
    {
        float elapsed = 0f;
        float duration = 3f;

        float jumpVelocity = 10f;
        float gravity = -36f;
        Vector3 velocity = Vector3.up * jumpVelocity;
        
        while (elapsed < duration)
        {
            transform.position += velocity * Time.deltaTime;
            velocity.y += gravity * Time.deltaTime;
            elapsed += Time.deltaTime;
            yield return null;
            
        }
    }
}
