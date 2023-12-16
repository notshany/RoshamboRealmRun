using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    AudioSource audioSource;
    
    private bool isTouchingGround;
    private float groundRadius = 0.1f; 
    [SerializeField] private Transform shoes;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        GroundCheck();
    }

    void Move()
    {
        float moveDirection = Input.GetAxis("Horizontal");

        // Flip the player's sprite if moving left
        if (moveDirection < 0)
        {
            spriteRenderer.flipX = true; // flip on the x axis
        }
        // Flip the player's sprite if moving right
        else if (moveDirection > 0)
        {
            spriteRenderer.flipX = false; // reset (facing right)
        }
       


        //calculate movement
        Vector2 movement = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        //apply movement to the rb
        rb.velocity = movement;
    }

    void Jump()
    {
        //check if player pressed jump
        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            //add jumpforce to y velocity
            rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
        }
    }

    void GroundCheck()
    {
        isTouchingGround = Physics2D.OverlapCircle(shoes.position, groundRadius, groundLayer); // origin point, radius, what it should overlap
        //Debug.Log(isTouchingGround);
    }




    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MovingPlatform"))
        {
            transform.SetParent(other.transform);  // Set the  parent to the moving platform
        }
        else if (other.CompareTag("Spikes"))
        {
            Debug.Log("you died!");
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MovingPlatform"))
        {
            // Reset the player's parent to null (no parent)
            transform.SetParent(null);
        }
    }


}