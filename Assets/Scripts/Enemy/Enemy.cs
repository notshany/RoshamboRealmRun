using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using static ShootableWall;

[System.Serializable]
public class Enemy : MonoBehaviour
{
    public enum EnemyType
    {
        Rock,
        Paper,
        Scissors
    }

    public EnemyType enemyType;
    public int maxHP;
    public int currentHP;
    public int damageToTake;
    public PlayerController playerController;
    private ScoreManager scoreManager;



    [SerializeField] private FloatingHealthBar healthBar;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        scoreManager = FindObjectOfType<ScoreManager>();
        currentHP = maxHP; // starts the hp as the max hp at the start of the game
    }

    private void Update()
    {
        damageToTake = playerController.currentCharacter.damage;
        DeathCheck();

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            TakeDamage();
        }
    }

    [ContextMenu("Take Damage")]
    public void TakeDamage()
    {

        if (enemyType.ToString() == "Rock" && playerController.currentCharacter.characterType == "Paper")        {
            Debug.Log("Rock got hit by Paper");
            currentHP -= damageToTake;
        }
        else if (enemyType.ToString() == "Paper" && playerController.currentCharacter.characterType == "Scissors")
        {
            Debug.Log("Paper got hit by Scissors");
            currentHP -= damageToTake;
        }
        else if (enemyType.ToString() == "Scissors" && playerController.currentCharacter.characterType == "Rock")
        {
            Debug.Log("Scissors got hit by Rock");
            currentHP -= damageToTake;
        }
        else
        {
            Debug.Log("no damage dealth");
        }

        healthBar.UpdateHealthBar(currentHP, maxHP);
    }

    public void DeathCheck()
    {
        if (currentHP <= 0)
        {
            gameObject.SetActive(false); // hides the object
            scoreManager.AddScore(10); // change score
        }
    }

}
