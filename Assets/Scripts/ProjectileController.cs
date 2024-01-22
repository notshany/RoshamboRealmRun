using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private PlayerController shootingPlayer;
    [SerializeField] Sprite[] projectileSprites;

    public void SetShootingCharacter(PlayerController player)
    {
        shootingPlayer = player;

        if (shootingPlayer != null)
        {
            SpriteRenderer projectileSpriteRenderer = GetComponent<SpriteRenderer>();

            switch (shootingPlayer.currentCharacter.characterType)
            {
                case "Rock":
                    projectileSpriteRenderer.sprite = projectileSprites[0];
                    break;
                case "Paper":
                    projectileSpriteRenderer.sprite = projectileSprites[1];
                    break;
                case "Scissors":
                    projectileSpriteRenderer.sprite = projectileSprites[2];
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