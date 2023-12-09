using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject player;
    //Make sure to assign the player game object to the player variable in the Unity Inspector.
    private int enemyType;

    void Start()
    {
        int playerType = player.GetComponent<PlayerManager>().GetPlayerType();
        if (playerType == 1)
        {
            enemyType = 2; // Start with paper if player started with rock
        }
        else if (playerType == 2)
        {
            enemyType = 3; // Start with scissors if player started with paper
        }
        else
        {
            enemyType = 1; // Start with rock if player started with scissors
        }
    }

    void Update()
    {
        int randomNumber = Random.Range(1, 4);
        if (randomNumber != player.GetComponent<PlayerManager>().GetPlayerType())
        {
            enemyType = randomNumber;
        }
        else
        {
            if (enemyType == 1)
            {
                enemyType = 2; // Switch to paper if enemy was rock and player is also rock
            }
            else if (enemyType == 2)
            {
                enemyType = 3; // Switch to scissors if enemy was paper and player is also paper
            }
            else
            {
                enemyType = 1; // Switch to rock if enemy was scissors and player is also scissors
            }
        }
    }

    public int GetEnemyType()
    {
        return enemyType;
    }
}