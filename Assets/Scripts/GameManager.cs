using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public int selectedCharIndex;

    [SerializeField] GameObject playerPrefab;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void InstantiatePlayer(int charIndex)
    {
        Debug.Log("Instantiating Player with CharIndex: " + charIndex);
        var player = Instantiate(playerPrefab, new Vector3(-6, 2, 0), Quaternion.identity);
        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.SwitchCharacter(playerController.characters[charIndex]);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Game")
        {
            InstantiatePlayer(selectedCharIndex);
        }
    }
    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void ResetGame()
    {
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        scoreManager.ResetScore();

    }




}