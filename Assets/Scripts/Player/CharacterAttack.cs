using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject projectilePrefab;
    [SerializeField] private PlayerController player;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private int shotForce;

    void Update()
    {
        if (player.currentCharacter.isActive && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, transform.rotation);

        ProjectileController projectileController = projectile.GetComponent<ProjectileController>();

        if (projectileController != null)
        {
            projectileController.SetShootingCharacter(player);

            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();

            if (projectileRb != null)
            {
                Vector2 force = new Vector2(playerMovement.direction * shotForce, 0f);
                projectileRb.AddForce(force, ForceMode2D.Impulse);
            }
        }
    }
}