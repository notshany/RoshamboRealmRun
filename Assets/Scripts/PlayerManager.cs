using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private float groundRadius = 0.1f;
    public RPS characterType;
    public int damage;
    public int health;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); 
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {


        //The player must click on 1, 2, or 3 to switch between characters.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            characterType = RPS.Rock;
            damage = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            characterType = RPS.Paper;
            damage = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            characterType = RPS.Scissors;
            damage = 1;
        }
        gameManager.currentRPSType = characterType;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        //NOTE: use TAGS for enemies!
        if (collision.gameObject.CompareTag("Enemy"))
        {
            int damageTaken = GetDamage(collision.gameObject.GetComponent<AIController>().GetEnemyType());
            collision.gameObject.GetComponent<Health>().TakeDamage(damageTaken);
        }
    }

    // Determine the damage dealt based on the character types.
    private int GetDamage(AIController.RPSCharacter.RPS enemyType)
    {
        int damageTaken = 0;

        if (characterType == RPS.Rock && enemyType == AIController.RPSCharacter.RPS.Scissors ||
                characterType == RPS.Paper && enemyType == AIController.RPSCharacter.RPS.Rock ||
                characterType == RPS.Scissors && enemyType == AIController.RPSCharacter.RPS.Paper)
        {
            damageTaken = damage;
        }

        return damageTaken;
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
            // Reset the player's parent to null (no parent)
            transform.SetParent(null);
        }
    }
}
