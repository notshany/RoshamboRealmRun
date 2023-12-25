using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character : MonoBehaviour
{
    public string characterType;
    public int maxHP;
    public int currentHP;
    public int damage;
    public string attackType;
    public Sprite characterSprite;
    private bool isRespawning = false;
    public float respawnTime = 10f;
    public bool isActive = false;


    private void Start()
    {
        currentHP = maxHP; // starts the hp as the max hp at the start of the game
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
    }

    public void DeathCheck()
    {
        if (currentHP <= 0 && !isRespawning) // if the characters hp is 0 or less and its not currently waiting to respawn, wait the respawnTime and call RespawnCharacter
        {
            isRespawning = true;
            Invoke("RespawnCharacter", respawnTime);
        }
    }

    private void RespawnCharacter() // sets hp back to max hp
    {
        currentHP = maxHP;
        isRespawning = false;
    }


}

