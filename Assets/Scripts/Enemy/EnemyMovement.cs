using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float range = 5f;
    public float followRangeX = 8f;
    public Transform player;
    private Vector2 originalPosition;
    private bool isFollowingPlayer = false;
    private bool isMovingRight = true;
    [SerializeField] SpriteRenderer spriteRenderer;
    private void Start()
    {
        originalPosition = transform.position;
        player = FindObjectOfType<PlayerController>().transform;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }


    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < followRangeX && Mathf.Abs(player.position.y - transform.position.y) < range)
        {
            if (!isFollowingPlayer)
            {
                isFollowingPlayer = true;
                FlipSprite();
            }

            FollowPlayer();
        }
        else
        {
            if (isFollowingPlayer)
            {
                isFollowingPlayer = false;
                FlipSprite();
            }

            Move();
        }
    }

    private void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void Move()
    {
        if (isMovingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x >= originalPosition.x + range)
            {
                isMovingRight = false;
                FlipSprite();
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= originalPosition.x - range)
            {
                isMovingRight = true;
                FlipSprite();
            }
        }
    }

    private void FlipSprite()
    {

        if (isFollowingPlayer)
        {
            spriteRenderer.flipX = (player.position.x < transform.position.x);
        }
        else
        {
            spriteRenderer.flipX = !isMovingRight;
        }
    }
}