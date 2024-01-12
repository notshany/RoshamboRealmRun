using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public TextMeshProUGUI HPText;
    public PlayerController playerController;
    [SerializeField] private Slider healthBar;


    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        HPText.text = "HP: " + playerController.currentCharacter.currentHP.ToString();
        float currentHp = playerController.currentCharacter.currentHP;

        healthBar.value = currentHp / playerController.currentCharacter.maxHP;
    }

}
