using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Slider healthbarsprite;

    public void UpdateHealthBar(float currentHealth)
    {
        healthbarsprite.value = currentHealth;
    }

    public void setHealthBar(float maxHealth, float currentHealth)
    {
        healthbarsprite.value = currentHealth;
        healthbarsprite.maxValue = maxHealth;
    }
}
