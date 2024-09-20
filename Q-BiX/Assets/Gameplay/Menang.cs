using UnityEngine;
using UnityEngine.UI;

public class Menang : MonoBehaviour
{
    public GameObject targetObject; // Object yang akan dicek/dihancurkan
    public Text displayText; // UI Text untuk menampilkan pesan

    private bool objectDestroyed = false; // Flag untuk memastikan teks hanya muncul sekali

    void Update()
    {
        // Cek jika object sudah dihancurkan atau tidak ada di scene
        if (targetObject == null && !objectDestroyed)
        {
            Debug.Log("Target object destroyed or null."); // Debugging untuk memastikan object dihancurkan

            if (displayText != null)
            {
                Debug.Log("Displaying text."); // Debugging untuk memastikan teks diaktifkan
                displayText.gameObject.SetActive(true); // Aktifkan teks jika dinonaktifkan
            }
            else
            {
                Debug.LogWarning("Display text is not assigned.");
            }

            objectDestroyed = true;
        }
    }
}
