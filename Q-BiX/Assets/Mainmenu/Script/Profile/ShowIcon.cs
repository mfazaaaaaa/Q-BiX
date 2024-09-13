using UnityEngine;
using UnityEngine.UI;

public class ShowIcon : MonoBehaviour
{
    public Image profileIconImage;  // Tempat untuk menampilkan ikon profil di Main Menu
    public Sprite[] profileIcons;   // Array yang berisi semua ikon profil

    void Start()
    {
        // Memuat ikon profil yang dipilih dari PlayerPrefs
        if (PlayerPrefs.HasKey("SelectedProfileIcon"))
        {
            int selectedIconIndex = PlayerPrefs.GetInt("SelectedProfileIcon");
            profileIconImage.sprite = profileIcons[selectedIconIndex];
        }
    }
}
