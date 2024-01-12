using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;

public class LeaderboardManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        // Retrieve the leaderboard data
        List<LeaderboardEntry> leaderboard = GetLeaderboard();

        Debug.Log("Leaderboard retrieved successfully."); // Add this line

        // Display the leaderboard
        DisplayLeaderboard(leaderboard);
    }

    public void GoToMainMenu()
    {
        // Load the main menu scene
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("game");
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

    private void DisplayLeaderboard(List<LeaderboardEntry> leaderboard)
    {
        // Sort the leaderboard entries by score (highest to lowest)
        leaderboard.Sort((a, b) => b.score.CompareTo(a.score));

        // Clear previous leaderboard entries
        nameText.text = string.Empty;
        scoreText.text = string.Empty;

        // Display the leaderboard entries
        for (int i = 0; i < leaderboard.Count; i++)
        {
            LeaderboardEntry entry = leaderboard[i];
            string entryText = $"{i + 1}. {entry.playerName}\n";
            string scoreEntryText = Mathf.RoundToInt(entry.score).ToString(); // Round the score to an integer

            // Append the entry text to the name text
            nameText.text += entryText;

            // Append the score entry text to the score text
            scoreText.text += scoreEntryText + "\n";
        }
    }


    private string GetLeaderboardFilePath()
    {
        // Create a file path using the persistent data path and a file name
        string fileName = "leaderboardData.json";
        return Path.Combine(Application.persistentDataPath, fileName);
    }
}

[System.Serializable]
public class LeaderboardEntry
{
    public string playerName;
    public float score;

    public LeaderboardEntry(string name, float score)
    {
        playerName = name;
        this.score = score;
    }
}

[System.Serializable]
public class LeaderboardData
{
    public List<LeaderboardEntry> leaderboardEntries;
}
