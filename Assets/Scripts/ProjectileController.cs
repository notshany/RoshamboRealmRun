using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Vector2 direction; // The direction in which the projectile will move
    [SerializeField] int speed = 5;
    void Update()
    {
        // Move the projectile in the specified direction
        transform.Translate(direction * Time.deltaTime * speed);
    }

    // Set the direction of the projectile
    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit!");
            // Add whatever logic makes the enemy take damage
        }

        // Destroy the projectile when it hits any collider
        // Destroy(gameObject);
    }
}