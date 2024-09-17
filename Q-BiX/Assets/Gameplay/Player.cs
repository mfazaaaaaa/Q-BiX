using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the player
    public int currentHealth;   // Current health of the player
    public HealthBar healthBar; // Reference to the health bar UI element

    public static Action OnPlayerDeath;  // Event for player death
    public static Action OnEnemyDeath;   // Event for enemy death

    private void Start()
    {
        currentHealth = maxHealth;       // Initialize the player's health
        healthBar.SetMaxHealth(maxHealth); // Set the health bar to maximum
    }

    private void Update()
    {
        // Test damage input
        if (Input.GetKeyDown(KeyCode.R))
        {
            TakeDamage(40); // Damage the player by 40 when 'R' is pressed
        }

        // Test heal input
        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(10); // Heal the player by 10 when 'H' is pressed
        }
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage.");
        }

        currentHealth -= damage;                     // Reduce the current health by the damage amount
        healthBar.SetHealth(currentHealth);          // Update the health bar UI

        if (currentHealth <= 0)
        {
            Die();                                   // Call Die method if health reaches 0
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing.");
        }

        bool wouldBeOverMaxHealth = currentHealth + amount > maxHealth;

        if (wouldBeOverMaxHealth)
        {
            currentHealth = maxHealth;              // Cap health at the maximum
        }
        else
        {
            currentHealth += amount;                // Add health normally
        }

        healthBar.SetHealth(currentHealth);         // Update the health bar UI
    }

    private void Die()
    {
        Debug.Log("Enemy is Dead!");
        Destroy(gameObject);                          // Destroy the player object

        if (this.CompareTag("Player"))
        {
            Time.timeScale = 0;                       // Pause the game on player death
            OnPlayerDeath?.Invoke();                  // Invoke player death event
        }
        else
        {
            OnEnemyDeath?.Invoke();                   // Invoke enemy death event if applicable
        }
    }
}
