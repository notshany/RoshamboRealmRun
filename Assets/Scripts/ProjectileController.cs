using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private PlayerController shootingPlayer;

    public void SetShootingCharacter(PlayerController player)
    {
        shootingPlayer = player;

        if (shootingPlayer != null)
        {
            SpriteRenderer projectileSpriteRenderer = GetComponent<SpriteRenderer>();

            switch (shootingPlayer.currentCharacter.characterType)
            {
                case "Rock":
                    projectileSpriteRenderer.color = Color.red;
                    break;
                case "Paper":
                    projectileSpriteRenderer.color = Color.green;
                    break;
                case "Scissors":
                    projectileSpriteRenderer.color = Color.blue;
                    break;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
        Debug.Log($"Enemy hit! by {shootingPlayer.currentCharacter.characterType}");
        }

        Destroy(gameObject);
    }
}