using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HighScoreDisplay : MonoBehaviour
{
    private const string HighScoreKey = "HighScore";

    public TextMeshProUGUI highestScore;
    public TextMeshProUGUI higherScore;
    public TextMeshProUGUI highScore;

    private void Start()
    {
        InitializeHighScores();
        DisplayHighScores();
    }


    private void InitializeHighScores()
    {
        if (!PlayerPrefs.HasKey(HighScoreKey))
        {
            for (int i = 1; i <= 3; i++)
            {
                PlayerPrefs.SetInt($"{HighScoreKey}{i}", 0);
                PlayerPrefs.SetString($"{HighScoreKey}Name{i}", "Player");
            }
        }
    }
    public void UpdateHighScores(string playerName, int score)
    {
        for (int i = 1; i <= 3; i++)
        {
            int currentScore = PlayerPrefs.GetInt($"{HighScoreKey}{i}");
            if (score > currentScore)
            {
                PlayerPrefs.SetInt($"{HighScoreKey}{i}", score);
                PlayerPrefs.SetString($"{HighScoreKey}Name{i}", playerName);
                // Update only the top scores
                break;
            }
        }

        DisplayHighScores();
    }

    private void DisplayHighScores()
    {
        string playerName = PlayerPrefs.GetString($"{HighScoreKey}Name{1}");
        int score = PlayerPrefs.GetInt($"{HighScoreKey}{1}");
        highestScore.text = $"{playerName}: {score}";

        playerName = PlayerPrefs.GetString($"{HighScoreKey}Name{2}");
        score = PlayerPrefs.GetInt($"{HighScoreKey}{2}");
        higherScore.text = $"{playerName} :  {score}";

        playerName = PlayerPrefs.GetString($"{HighScoreKey}Name{3}");
        score = PlayerPrefs.GetInt($"{HighScoreKey}{3}");
        highScore.text = $"{playerName} :  {score}";
    }
}
