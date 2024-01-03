using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseCharacter : MonoBehaviour, IPointerClickHandler
{
    private GameManager gameManger;

    private void Start()
    {
        gameManger = FindObjectOfType<GameManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        gameManger.playerSprite = gameObject.GetComponent<Image>().sprite;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(1);
        gameManger.InstantiatePlayer();
        //Destroy(gameObject); // this is the thing that made the sprite lag before the start of the game scene lol
    }


}
