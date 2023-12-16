using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseCharacter : MonoBehaviour, IPointerClickHandler
{
    private ChooseCharacterActivator chooseCharacterActivator;

    private void Start()
    {
        chooseCharacterActivator = FindObjectOfType<ChooseCharacterActivator>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        chooseCharacterActivator.playerSprite = gameObject.GetComponent<Image>().sprite;
        SceneManager.LoadScene(1);
    }


}
