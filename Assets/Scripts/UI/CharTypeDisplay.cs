using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharTypeDisplay : MonoBehaviour
{
    public TextMeshProUGUI CharText;
    public PlayerController playerController;
    public Image[] characterIcons;
    public TextMeshProUGUI[] respawnCountdownTexts;
    public Color activeCharColor;
    public Color notActiveCharColor;
    public Color deadCharColor;
    private Dictionary<Character, TextMeshProUGUI> characterToCountdownText = new Dictionary<Character, TextMeshProUGUI>();


    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        MapCharacterCountdown();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCharText();
        UpdateCharIcons();
        UpdateRespawnCountdown();
    }

    public void UpdateCharText()
    {
        CharText.text = playerController.currentCharacter.characterType;
    }
    void MapCharacterCountdown()
    {
        for (int i = 0; i < playerController.characters.Length; i++)
        {
            characterToCountdownText[playerController.characters[i]] = respawnCountdownTexts[i];
        }
    }
    void UpdateCharIcons()
    {
        string currentCharType = playerController.currentCharacter.characterType;

        for (int i = 0; i < playerController.characters.Length; i++)
        {
            Image icon = characterIcons[i];
            bool isCurrentChar = playerController.characters[i].characterType == currentCharType;
            bool isAlive = playerController.characters[i].isAlive;

            icon.color = isCurrentChar ? activeCharColor : (isAlive ? notActiveCharColor : deadCharColor);
        }
    }

    void UpdateRespawnCountdown()
    {
        foreach (var character in playerController.deadCharacters)
        {
            if (character != null && characterToCountdownText.TryGetValue(character, out TextMeshProUGUI countdownText))
            {
                float remainingTime = Mathf.Max(0f, character.deathTime + character.respawnTime - Time.time);

                countdownText.text = (remainingTime > 0f) ? $"{Mathf.CeilToInt(remainingTime)}s" : "";
            }
        }
    }

}

