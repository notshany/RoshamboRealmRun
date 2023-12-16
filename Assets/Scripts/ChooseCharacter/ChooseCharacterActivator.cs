using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseCharacterActivator : MonoBehaviour
{
    public Sprite playerSprite;
    public GameObject playerPrefab;

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == SceneManager.GetSceneByBuildIndex(1).name)
        {
            var player = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            player.GetComponent<SpriteRenderer>().sprite = playerSprite;
        }
    }
}
