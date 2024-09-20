using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Jika Anda menggunakan teks legacy

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Pastikan GameManager tidak dihapus ketika pindah scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

    }

    public void GoToMainMenu(float delay)
    {
        Invoke("LoadMainMenu", delay);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }
}
