using UnityEngine;
using UnityEngine.UI;

public class PlayerProfileManager : MonoBehaviour
{
    public InputField playerNameInput;  // InputField untuk memasukkan nama player
    public Text displayNameText;        // Text UI untuk menampilkan nama player

    void Start()
    {
        // Memeriksa apakah ada nama player yang tersimpan di PlayerPrefs
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            // Memuat nama player yang tersimpan
            string savedName = PlayerPrefs.GetString("PlayerName");

            // Menampilkan nama player di InputField dan di Text UI
            playerNameInput.text = savedName;
            displayNameText.text = savedName;
        }
    }

    // Dipanggil saat tombol Save ditekan
    public void SaveProfile()
    {
        string playerName = playerNameInput.text;  // Mendapatkan teks dari InputField
        if (!string.IsNullOrEmpty(playerName))     // Memastikan nama tidak kosong
        {
            // Simpan nama player ke PlayerPrefs
            PlayerPrefs.SetString("PlayerName", playerName);
            PlayerPrefs.Save();

            // Tampilkan nama player di UI setelah disimpan
            displayNameText.text = playerName;
        }
    }
}
