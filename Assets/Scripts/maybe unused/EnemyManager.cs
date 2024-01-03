using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    GameManager gameManager;
    RPS enemyType;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        RPS playerType = gameManager.currentRPSType;
        if (playerType == RPS.Rock)
        {
            enemyType = RPS.Paper;
        }
        else if (playerType == RPS.Paper)
        {
            enemyType = RPS.Scissors;
        }
        else
        {
            enemyType = RPS.Rock;
        }
    }

    void Update()
    {
        //if rock become paper enemies if paper become scissors if scissors become rock.
        if (gameManager.currentRPSType == RPS.Rock)
        {
            enemyType = RPS.Paper;
        }
        else if (gameManager.currentRPSType == RPS.Paper)
        {
            enemyType= RPS.Scissors;
        }
        else if (gameManager.currentRPSType == RPS.Scissors)
        {
            enemyType = RPS.Rock;
        }
    }
}