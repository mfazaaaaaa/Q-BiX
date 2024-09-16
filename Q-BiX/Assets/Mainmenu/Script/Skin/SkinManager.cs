using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public Image[] characterPreviewParts;    // Bagian tubuh di preview menu skin (misalnya kepala, badan, kaki)
    public Image[] mainMenuCharacterParts;   // Bagian tubuh di tampilan main menu
    public Image[] weapCharacterParts;

    public Sprite[] yellowSkinSprites; // Sprite untuk skin kuning (setiap array elemen berisi bagian tubuh yang berbeda)
    public Sprite[] blueSkinSprites;   // Sprite untuk skin biru
    public Sprite[] greenSkinSprites;  // Sprite untuk skin hijau
    public Sprite[] pinkSkinSprites;   // Sprite untuk skin pink

    public Button[] skinButtons;       // Tombol untuk memilih skin

    private Sprite[] selectedSkin;     // Skin yang sedang dipilih

    void Start()
    {
        // Assign listener ke setiap tombol skin
        skinButtons[0].onClick.AddListener(() => SelectSkin(yellowSkinSprites)); // Tombol skin kuning
        skinButtons[1].onClick.AddListener(() => SelectSkin(blueSkinSprites));   // Tombol skin biru
        skinButtons[2].onClick.AddListener(() => SelectSkin(greenSkinSprites));  // Tombol skin hijau
        skinButtons[3].onClick.AddListener(() => SelectSkin(pinkSkinSprites));   // Tombol skin pink

        // Muat skin yang terakhir dipilih
        LoadSkinPreference();
    }

    // Fungsi untuk memilih skin
    void SelectSkin(Sprite[] skinSprites)
    {
        selectedSkin = skinSprites;

        // Ganti sprite di preview menu skin
        for (int i = 0; i < characterPreviewParts.Length; i++)
        {
            characterPreviewParts[i].sprite = selectedSkin[i];
        }

        // Ganti sprite di main menu
        for (int i = 0; i < mainMenuCharacterParts.Length; i++)
        {
            mainMenuCharacterParts[i].sprite = selectedSkin[i];
        }

        // Ganti sprite di preview weap
        for (int i = 0; i < weapCharacterParts.Length; i++)
        {
            weapCharacterParts[i].sprite = selectedSkin[i];
        }

        // Simpan skin yang dipilih
        SaveSkinPreference();
    }

    // Fungsi untuk menyimpan skin yang dipilih
    void SaveSkinPreference()
    {
        // Simpan indeks skin yang dipilih di PlayerPrefs
        int skinIndex = 0; // Default 0 untuk kuning
        if (selectedSkin == yellowSkinSprites)
        {
            skinIndex = 0;
        }
        else if (selectedSkin == blueSkinSprites)
        {
            skinIndex = 1;
        }
        else if (selectedSkin == greenSkinSprites)
        {
            skinIndex = 2;
        }
        else if (selectedSkin == pinkSkinSprites)
        {
            skinIndex = 3;
        }

        PlayerPrefs.SetInt("SelectedSkinIndex", skinIndex);
        PlayerPrefs.Save();
    }

    // Fungsi untuk memuat skin terakhir yang dipilih
    void LoadSkinPreference()
    {
        int skinIndex = PlayerPrefs.GetInt("SelectedSkinIndex", 0); // Default skin adalah kuning (indeks 0)

        switch (skinIndex)
        {
            case 0:
                SelectSkin(yellowSkinSprites);
                break;
            case 1:
                SelectSkin(blueSkinSprites);
                break;
            case 2:
                SelectSkin(greenSkinSprites);
                break;
            case 3:
                SelectSkin(pinkSkinSprites);
                break;
            default:
                SelectSkin(yellowSkinSprites);
                break;
        }
    }
}