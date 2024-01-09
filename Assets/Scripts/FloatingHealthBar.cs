using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthBar;

    public void UpdateHealthBar(float currentHp, float maxHp)
    {
        healthBar.value = currentHp / maxHp;
    }
}
