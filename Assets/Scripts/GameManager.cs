using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    public Sprite playerSprite;
    public GameObject playerPrefab;
    [SerializeField] private GameObject pauseMenuPrefab;
    public bool pauseMenuOn = false;
    public int score;
    public List<PlayerPrefs> HighScoresNumbers = new List<PlayerPrefs>();

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

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == SceneManager.GetSceneByBuildIndex(1).name)
        {
            var player = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            player.GetComponent<SpriteRenderer>().sprite = playerSprite;
        }

        if (Input.GetKeyUp(KeyCode.Escape) && !pauseMenuOn) 
        { 
            pauseMenuOn = true;
            Instantiate(pauseMenuPrefab);
        }
    }
}
