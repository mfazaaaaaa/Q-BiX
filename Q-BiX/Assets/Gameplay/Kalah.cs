using UnityEngine;
using UnityEngine.UI; // Pastikan ini di-import

public class Kalah : MonoBehaviour
{
    public GameObject targetObject; // Object yang akan dicek/dihancurkan
    public Text displayText; // UI Text untuk menampilkan pesan (legacy)

    private bool objectDestroyed = false; // Flag untuk memastikan teks hanya muncul sekali

    void Start()
    {
        if (displayText != null)
        {
            displayText.gameObject.SetActive(false); // Matikan teks di awal
        }
        else
        {
            Debug.LogWarning("Display text is not assigned in the Inspector.");
        }
    }

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

            objectDestroyed = true; // Pastikan hanya dijalankan sekali
        }
    }
}
