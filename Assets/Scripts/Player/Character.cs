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
    public bool isRespawning = false;
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

    private void RespawnCharacter() // sets hp back to max hp
    {
        currentHP = maxHP;
        isRespawning = false;
    }


}

