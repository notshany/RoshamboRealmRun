using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseCharacter : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameManager gameManger;
    public int charIndex;

    private void Start()
    {
        gameManger = FindObjectOfType<GameManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        gameManger.selectedCharIndex = charIndex;
        Debug.Log("Button Clicked - CharIndex: " + charIndex);
        SceneManager.LoadScene("Game");
    }
}
