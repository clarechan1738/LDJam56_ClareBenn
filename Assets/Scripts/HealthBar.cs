using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //Health Bar Slider
    public Slider healthBar;

    //Sets The Max Health
    public void SetMaxHealth(int health)
    {
        healthBar.maxValue = health;
        healthBar.value = health;
    }


    //Sets Current Health
    public void SetHealth(int health)
    {
        healthBar.value = health;
    }
}
