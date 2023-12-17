using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameForHighScore : MonoBehaviour
{
    [SerializeField] InputField inputField;
    private GameManager gameManager;
    HighScoreDisplay highScoreDisplayScript;

    void Start()
    {
        highScoreDisplayScript = gameObject.GetComponent<HighScoreDisplay>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void OnEndEdit(string name)
    {
        print (name);
        highScoreDisplayScript.UpdateHighScores(name, gameManager.score);
    }
}
