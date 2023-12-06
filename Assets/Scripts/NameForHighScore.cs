using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameForHighScore : MonoBehaviour
{
    public InputField playerNameInput;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerNameInput.onEndEdit.AddListener(SubmitName);
    }

    private void SubmitName(string name)
    {
        // Store the player's name (you can save it to PlayerPrefs or a GameManager)
        PlayerPrefs.SetInt(name,gameManager.score);
        PlayerPrefs.SetString(name,name);
    }
}
