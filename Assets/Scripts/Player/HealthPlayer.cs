using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public HealthBarPlayer healthBarPlayer;

    public int maxHealth;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBarPlayer.SetMaxHealth(currentHealth);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            TakeDamage(10);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBarPlayer.SetHealth(currentHealth);
    }
}
