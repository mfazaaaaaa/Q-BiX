using UnityEngine;
using UnityEngine.UI;

public class PlayerNameDisplay : MonoBehaviour
{
    public Text playerNameText;  // Text UI untuk menampilkan nama player di scene gameplay

    void Start()
    {
        // Memeriksa apakah ada nama player yang tersimpan di PlayerPrefs
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            // Memuat nama player yang tersimpan
            string playerName = PlayerPrefs.GetString("PlayerName");

            // Menampilkan nama player di Text UI di scene gameplay
            playerNameText.text = playerName;
        }
        else
        {
            // Jika tidak ada nama player yang tersimpan, tampilkan teks default
            playerNameText.text = "Player";
        }
    }
}
