using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float groundRadius = 0.1f;
    public float moveSpeed;
    public float jumpForce;
    private bool isTouchingGround;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform shoes;
    [SerializeField] private LayerMask groundLayer;
    private int jumpCounter = 0;
    [SerializeField] private Transform projectileOrigin;
    public int direction;
    private Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();

    }

    void Update()
    {
        Move();
        Jump();
        GroundCheck();
    }
    void Move()
    {
        float moveDirection = Input.GetAxis("Horizontal");

        // instead of flipping the player which results in camera follow player problems
        // we change the position of the projectile origin point
        if (moveDirection < 0)
        {
            projectileOrigin.localPosition = new Vector3(-0.8f, 0f, 0f);
            direction = -1;
        }
        // Flip the projectile if moving right
        else if (moveDirection > 0)
        {
            projectileOrigin.localPosition = new Vector3(0.8f, 0f, 0f);
            direction = 1;

        }

        // Set the "isRunning" parameter based on movement
        animator.SetBool("isWalking", Mathf.Abs(moveDirection) > 0);;
        animator.SetBool("isIdle", Mathf.Abs(moveDirection) == 0);
        //calculate movement
        Vector2 movement = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        //apply movement to the rb
        rb.velocity = movement;
    }


    void GroundCheck()
    {
        isTouchingGround = Physics2D.OverlapCircle(shoes.position, groundRadius, groundLayer); // origin point, radius, what it should overlap
        if (isTouchingGround)
        {
            jumpCounter = 0;
        }
    }
    void Jump()
    {

        //check if player pressed jump
        if (Input.GetButtonDown("Jump"))
        {
            if (jumpCounter < 1)
            {
                //add jumpforce to y velocity
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpCounter++;
            }
            if (jumpCounter == 1)
            {
                //add jumpforce to y velocity
                if (isTouchingGround)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    jumpCounter++;
                }
            }
        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MovingPlatform"))
        {
            transform.SetParent(other.transform);  // Set the  parent to the moving platform
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MovingPlatform"))
        {
            transform.SetParent(null); // Reset the player's parent to null (no parent)
        }
    }
}
