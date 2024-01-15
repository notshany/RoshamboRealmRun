using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableWall : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] private ScoreManager scoreManager;
    public enum DestroyableType
    {
        Rock,
        Paper,
        Scissors
    }

    [SerializeField] private DestroyableType destroyedByType;
    [SerializeField] private int score;
    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((playerController.currentCharacter.characterType == destroyedByType.ToString()) && (collision.gameObject.CompareTag("Projectile")))
        {
            gameObject.SetActive(false); // hides the object
            scoreManager.AddScore(10); // add score
        }
    }
}
