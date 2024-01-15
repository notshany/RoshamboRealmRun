using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TMP_InputField nameInputField;
    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

        // Display the final score
        float finalScore = scoreManager.currentScore;
        scoreText.text = Mathf.RoundToInt(finalScore).ToString();

        // Make the input field active and selected
        nameInputField.Select();
        nameInputField.ActivateInputField();
    }

    public void GoToMainMenu()
    {
        scoreManager.ResetScore();
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        scoreManager.ResetScore();
        SceneManager.LoadScene("Game");
    }

    public void SaveScore()
    {
        string playerName = nameInputField.text;
        float score = scoreManager.currentScore;

        if (string.IsNullOrEmpty(playerName))
        {
            Debug.Log("Player name is empty. Score not saved.");
            return;
        }

        // Retrieve the leaderboard data
        List<LeaderboardEntry> leaderboard = GetLeaderboard();

        // Add the new entry to the leaderboard
        leaderboard.Add(new LeaderboardEntry(playerName, score));

        // Sort the leaderboard entries by score (highest to lowest)
        leaderboard.Sort((a, b) => b.score.CompareTo(a.score));

        Debug.Log("Leaderboard saved successfully."); // Add this line

        // Save the leaderboard data
        SaveLeaderboard(leaderboard);
        scoreManager.ResetScore();
        // Load the leaderboard scene
        SceneManager.LoadScene("leaderboard");
    }

    private List<LeaderboardEntry> GetLeaderboard()
    {
        // Check if the leaderboard data file exists
        if (File.Exists(GetLeaderboardFilePath()))
        {
            // Load the JSON string from the file
            string leaderboardJson = File.ReadAllText(GetLeaderboardFilePath());

            // Deserialize the JSON string into the leaderboard data
            return JsonUtility.FromJson<LeaderboardData>(leaderboardJson).leaderboardEntries;
        }

        // If no leaderboard file exists, return an empty list
        return new List<LeaderboardEntry>();
    }

    private void SaveLeaderboard(List<LeaderboardEntry> leaderboard)
    {
        // Create a LeaderboardData instance with the leaderboard entries
        LeaderboardData data = new LeaderboardData();
        data.leaderboardEntries = leaderboard;

        // Convert the leaderboard data to JSON
        string leaderboardJson = JsonUtility.ToJson(data);

        // Save the JSON string to the leaderboard file
        File.WriteAllText(GetLeaderboardFilePath(), leaderboardJson);
    }

    private string GetLeaderboardFilePath()
    {
        // Create a file path using the persistent data path and a file name
        string fileName = "leaderboardData.json";
        return Path.Combine(Application.persistentDataPath, fileName);
    }
}