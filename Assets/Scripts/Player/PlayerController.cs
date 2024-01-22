using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Character[] characters; // array of rock, paper, and scissors characters
    public Character currentCharacter; // a variable to hold the current active char
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    [SerializeField] GameManager gameManager;
    public List<Character> deadCharacters = new List<Character>(); // list to keep dead characters

    private void Start()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        DeathCheck();

        for (int i = 0; i < characters.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i) && i < characters.Length)
            {
                SwitchCharacter(characters[i]);
            }
        }
    }

    public void DeathCheck()
    {
        if (currentCharacter.currentHP <= 0 && !currentCharacter.isRespawning)
        {
            currentCharacter.isRespawning = true;
            Debug.Log(currentCharacter + " died");
            currentCharacter.isAlive = false;
            currentCharacter.deathTime = Time.time; // Record the time of death

            deadCharacters.Add(currentCharacter); // Add the dead character to the list

            int currentIndex = System.Array.IndexOf(characters, currentCharacter); // the index of the current character in the array

            int nextIndex = FindNextAliveCharacterIndex(currentIndex); // the next alive character in the array

            if (nextIndex != -1)
            {
                SwitchCharacter(characters[nextIndex]);
            }
            else
            {
                Debug.Log("all characters are dead!");
            }
        }

        // Check if any dead characters are ready to respawn
        for (int i = 0; i < deadCharacters.Count; i++)
        {
            if (Time.time - deadCharacters[i].deathTime >= deadCharacters[i].respawnTime)
            {
                RespawnDeadCharacter(deadCharacters[i]);
                deadCharacters.RemoveAt(i);
                i--; // Adjust the index since we removed an element from the list
            }
        }
    }

    private int FindNextAliveCharacterIndex(int currentIndex)
    {
        for (int i = currentIndex + 1; i < characters.Length; i++)
        {
            if (characters[i].currentHP > 0)
            {
                return i;
            }
        }

        for (int i = 0; i < currentIndex; i++) // if no next alive character is found, loop from the beginning
        {
            if (characters[i].currentHP > 0)
            {
                return i;
            }
        }

        gameManager.isGameWon = false;
        SceneManager.LoadScene("WinScreen");
        return -1;
    }

    private void RespawnDeadCharacter(Character deadCharacter)
    {
        if (deadCharacter != null)
        {
            deadCharacter.RespawnCharacter();
        }
    }

    public void SwitchCharacter(Character newCharacter)
    {
        if (newCharacter.isAlive)
        {
            Debug.Log("switching character to " + newCharacter.name);

            if (currentCharacter != null)
            {
                currentCharacter.isActive = false;
            }

            currentCharacter = newCharacter;

            playerSpriteRenderer.sprite = currentCharacter.characterSprite;

            currentCharacter.isActive = true;
        }
        else
        {
            Debug.Log("cant switch to " + newCharacter.name + " because its dead");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentCharacter.TakeDamage(30);
        }
    }
}
