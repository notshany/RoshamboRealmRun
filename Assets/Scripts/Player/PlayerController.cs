using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Character[] characters; //array of the rock,paper anc scissors characters
    public Character currentCharacter; // a variable to hold the current active char
    private int currentCharacterIndex;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;

    private void Start()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();

        if (characters.Length > 0)
        {
            SwitchCharacter(characters[0]);
        }
        else
        {
            Debug.Log("no characters assigned to the player");
        }
    }

    private void Update()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i) && i < characters.Length)
            {
                SwitchCharacter(characters[i]);
            }
        }
    }

    public void SwitchCharacter(Character newCharacter)
    {
        if (currentCharacter != null)
        {
            currentCharacter.isActive = false;
        }

        currentCharacter = newCharacter;

        playerSpriteRenderer.sprite = currentCharacter.characterSprite;

        currentCharacter.isActive = true;
    }
}


