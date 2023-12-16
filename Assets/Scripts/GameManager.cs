using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    [SerializeField] GameObject playerPrefab;
    public Sprite playerSprite;
    public int score;

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
    }

<<<<<<< HEAD
    public void InstantiatePlayer()
    {
        if (SceneManager.GetActiveScene().name == SceneManager.GetSceneByBuildIndex(1).name)
        {
            var player = Instantiate(playerPrefab, new Vector3(-6, 2, 0), Quaternion.identity);
            player.GetComponent<SpriteRenderer>().sprite = playerSprite;
        }
    }
}
=======
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == SceneManager.GetSceneByBuildIndex(1).name)
        {
            var player = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            player.GetComponent<SpriteRenderer>().sprite = playerSprite;
        }

        if (Input.GetKeyUp(KeyCode.Escape) && !pauseMenuOn)  // pause 
        { 
            pauseMenuOn = true;
            Instantiate(pauseMenuPrefab);
        }
    }
}
>>>>>>> parent of a209bf3 (Added  a camera that follows the player)
