using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider; // Slider untuk health bar player
    public int maxHealth = 100;
    private int currentHealth;
    public EnemyFollow enemyFollow;

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

    // Update UI health bar player
    private void UpdateHealthUI()
    {
        healthSlider.value = currentHealth;
    }

    // Fungsi saat player mati
    private void Die()
    {
        enemyFollow.enabled = false;
        GameManager.instance.GoToMainMenu(1f);  // Pindah ke main menu setelah 2 detik
        Destroy(gameObject);  
    }

}
