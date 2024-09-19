using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // Tambahkan ini untuk UI

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;  // Menyimpan status pause
    public GameObject pauseMenuUI;        // Panel Pause Menu
    public Button pauseButton;            // Tombol UI untuk Pause

    void Start()
    {
        // Tambahkan listener ke tombol pause
        pauseButton.onClick.AddListener(TogglePause);
    }

    // Fungsi untuk toggle antara pause dan resume
    void TogglePause()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    // Resume game
    public void Resume()
    {
        pauseMenuUI.SetActive(false);     // Sembunyikan pause menu
        Time.timeScale = 1f;              // Set waktu kembali normal
        isPaused = false;                 // Update status pause
    }

    // Pause game
    void Pause()
    {
        pauseMenuUI.SetActive(true);      // Tampilkan pause menu
        Time.timeScale = 0f;              // Hentikan waktu game
        isPaused = true;                  // Update status pause
    }

    // Restart scene (ulang game)
    public void Restart()
    {
        Time.timeScale = 1f;              // Set waktu kembali normal sebelum restart
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Muat ulang scene aktif
    }

    // Kembali ke main menu
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;              // Set waktu kembali normal
        SceneManager.LoadScene("Mainmenu");  // Ganti nama scene ke nama main menu kamu
    }
}
