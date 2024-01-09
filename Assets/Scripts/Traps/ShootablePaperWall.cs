using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootablePaperWall : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision) // change to collision if projectiles are collidors and not triggers
    {
        if ((gameManager.currentRPSType == RPS.Scissors) && (collision.gameObject.CompareTag("Projectile")))
        {
            Destroy(gameObject);
        }
    }
}
