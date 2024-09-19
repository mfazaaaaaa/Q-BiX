using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider healthSlider; // Slider untuk health bar musuh
    public int maxHealth = 100;
    public int currentHealth;
    public PlayerMovement playerMovement;  // Reference ke script PlayerMovement

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

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

    private void UpdateHealthUI()
    {
        healthSlider.value = currentHealth;
    }

    private void Die()
    {
        playerMovement.enabled = false;  // Matikan script PlayerMovement
        Destroy(gameObject);  // Hapus musuh
        GameManager.instance.GoToMainMenu(1f);  // Pindah ke main menu setelah 2 detik
    }
}
