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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((gameManager.currentRPSType == RPS.Scissors) && (collision.gameObject.CompareTag("Projectile")))
        {
            Destroy(gameObject);
        }
    }
}
