using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScene : MonoBehaviour
{
    public float timeLeft = 300;
    public float timeSoFar = 0;
    public bool isRunning = false;
    public TextMeshProUGUI timerText;
    public GameManager gameManager;

    private void Start()
    {
        isRunning = true;
        gameManager = FindObjectOfType<GameManager>();

    }

    private void Update()
    {
        if (isRunning)
        {
            timeLeft -= Time.deltaTime;
            timeSoFar += Time.deltaTime;

            if (timeLeft <= 0)
            {
                gameManager.isGameWon = false;
                SceneManager.LoadScene("WinScreen");
                timeLeft = 0;
                isRunning = false;
            }

        }
        UpdateTimerUI();
    }

    private void UpdateTimerUI()
    {
       timerText.text = Mathf.RoundToInt(timeLeft).ToString();
    }
}
