using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesController : MonoBehaviour

{
    public bool isCollected = false;
    int Score = 5;
    public ScoreManager scoreManager;
    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isCollected && other.CompareTag("Player"))
        {
            isCollected = true;
            gameObject.SetActive(false); // hides the object
            scoreManager.AddScore(Score);
        }
    }


}

