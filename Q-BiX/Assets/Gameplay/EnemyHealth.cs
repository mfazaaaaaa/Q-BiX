using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider healthSlider; // Slider untuk health bar musuh
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    // Fungsi untuk menerima damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Update UI health bar musuh
    private void UpdateHealthUI()
    {
        healthSlider.value = currentHealth;
    }

    // Fungsi untuk menghilangkan musuh
    private void Die()
    {
        Destroy(gameObject);
    }
}
