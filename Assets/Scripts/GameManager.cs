using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum RPS
{
    //Different character types.
    Rock,
    Paper,
    Scissors
}

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    [SerializeField] GameObject playerPrefab;
    public Sprite playerSprite;
    public RPS currentRPSType;

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

    public void InstantiatePlayer()
    {
        if (SceneManager.GetActiveScene().name == SceneManager.GetSceneByBuildIndex(1).name)
        {
            var player = Instantiate(playerPrefab, new Vector3(-6, 2, 0), Quaternion.identity);
            player.GetComponent<SpriteRenderer>().sprite = playerSprite;
        }
    }
}