using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseWinScreens : MonoBehaviour
{
    public void OnGoBackToMainMenuClick()
    {
        SceneManager.LoadScene(0);
    }

    public void OnWatchHighScoresClicked()
    { SceneManager.LoadScene(2); }
}
