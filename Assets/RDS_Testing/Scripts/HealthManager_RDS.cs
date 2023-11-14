using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class HealthManager_RDS : MonoBehaviour
{
    public Image healthBar;
    public TMP_Text healthNumber;
    public float healthAmount = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
        {
            //death here
        }
        healthNumber.text = Math.Round(healthAmount).ToString();
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthNumber.text = Math.Round(healthAmount).ToString();
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthNumber.text = Math.Round(healthAmount).ToString();
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }
}
