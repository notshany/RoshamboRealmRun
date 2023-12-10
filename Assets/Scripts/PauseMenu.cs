using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Time.timeScale = 0.0f;
    }

    public void OnResumeButton()
    {
        OnExitMenu();
    }

    public void OnSettingsButton()
    {
        OnExitMenu();
        SceneManager.LoadScene(5); //change to name, add scene
    }

    public void OnBackToMainButton()
    {
        OnExitMenu();
        SceneManager.LoadScene(0);
    }
    void OnExitMenu()
    {
        gameManager.pauseMenuOn = false;
        Time.timeScale = 1f;
        Destroy(gameObject);
    }
}
