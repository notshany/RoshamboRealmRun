using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Traps : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] bool isDestroyable;
    [SerializeField] int damageToDeal = 10;


    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController.currentCharacter.TakeDamage(damageToDeal);

            if (isDestroyable)
            {
                gameObject.SetActive(false);
            }
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (isDestroyable)
            {
                gameObject.SetActive(false);
            }
        }
    }
}

