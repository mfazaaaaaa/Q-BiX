using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;  // Set the slider's maximum value
        slider.value = health;     // Initialize the slider to the max health
    }

    public void SetHealth(int health)
    {
        slider.value = health;     // Update the slider's value as the health changes
    }
}
