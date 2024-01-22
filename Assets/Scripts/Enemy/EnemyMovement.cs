using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float range = 5f;
    public float followRangeX = 8f; 
    public Transform player;
    public PlayerController playerController;
    public SpriteRenderer spriteRenderer;
    private Vector2 originalPosition;
    private bool isFollowingPlayer = false;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalPosition = transform.position;
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < followRangeX && Mathf.Abs(player.position.y - transform.position.y) < range)
        {
            // Enemy is within x-axis follow range, move towards the player
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            isFollowingPlayer = true;
        }
        else if (isFollowingPlayer)
        {
            // Enemy was following the player but is now out of follow range, smoothly transition back
            transform.position = Vector2.MoveTowards(transform.position, originalPosition, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, originalPosition) < 0.01f)
            {
                isFollowingPlayer = false;
            }
        }
        else
        {
            // enemy is outside playes range - pingpong
            float horizontalMovement = Mathf.PingPong(Time.time * speed, range * 2) - range;
            transform.position = new Vector2(originalPosition.x + horizontalMovement, transform.position.y);
        }
        FlipSprite();
    }

    private void FlipSprite()
    {
        float moveDirection = Input.GetAxis("Horizontal");

        if (moveDirection < 0)
        {
            spriteRenderer.flipX = false;

        }
        // flip sprite if moving right
        else if (moveDirection > 0)
        {

            spriteRenderer.flipX = true;
        }
    }
}
