using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit!");
            // Add whatever logic makes the enemy take damage
        }


        Destroy(gameObject);
    }
}