using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthController : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;
    public Image HealhtBar;
    public GameObject defeat;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
        UpdateHP();
    }
    public void UpdateHP()
    {
        HealhtBar.fillAmount = currentHealth / 100;
        if (currentHealth ==0) 
        {
            HealhtBar.fillAmount = 0/100;
        }
    }
    public void DamagePlayer(float damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateHP();
        if (currentHealth <=0)
        {
            Time.timeScale = 0;
            defeat.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
