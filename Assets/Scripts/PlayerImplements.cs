using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImplements : MonoBehaviour
{
    //should sit on the player, could be at player's collisions script.
    //should have a game manager reference

    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            //kill current player and start timer.
            switch (gameManager.currentRPSType)
            {
                case (RPS.Paper):
                    //kill paper, start timer
                    break;

                case (RPS.Scissors): 
                    //kill scissors and start timer
                    break;

                case (RPS.Rock): 
                    //kill rock
                    break;
            }
            //if statement: check if all 3 timers are active/ higher than 0. if they are, send to lose screen.

        }
    }
}
