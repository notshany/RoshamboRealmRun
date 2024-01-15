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

    private void Start()
    {
        isRunning = true;
    }

    private void Update()
    {
        if (isRunning)
        {
            timeLeft -= Time.deltaTime;
            timeSoFar += Time.deltaTime;

            if (timeLeft <= 0)
            {
                SceneManager.LoadScene(3);
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
