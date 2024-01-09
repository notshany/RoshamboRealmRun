using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootablePaperWall : MonoBehaviour
{
    private PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((playerController.currentCharacter.characterType == "Scissors") && (collision.gameObject.CompareTag("Projectile")))
        {
            Destroy(gameObject);
        }
    }
}
