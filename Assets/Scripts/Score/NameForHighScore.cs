using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameForHighScore : MonoBehaviour
{
    [SerializeField] InputField inputField;
    private ScoreManager scoreManager;
    HighScoreDisplay highScoreDisplayScript;

    void Start()
    {
        highScoreDisplayScript = gameObject.GetComponent<HighScoreDisplay>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void OnEndEdit(string name)
    {
        print (name);
        highScoreDisplayScript.UpdateHighScores(name, scoreManager.currentScore);
    }
}
