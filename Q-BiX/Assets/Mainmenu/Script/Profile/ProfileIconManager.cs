using UnityEngine;
using UnityEngine.UI;

public class ProfileIconManager : MonoBehaviour
{
    public Image previewImage;              // Tempat untuk menampilkan ikon yang dipilih
    public Sprite[] profileIcons;           // Array yang berisi semua ikon profil
    public Button[] iconButtons;            // Array yang berisi tombol untuk memilih ikon
    public Button equipButton;              // Tombol equip untuk mengonfirmasi pilihan
    public Image equipButtonImage;          // Image pada tombol Equip
    public Sprite equipSprite;              // Sprite untuk tombol "Equip"
    public Sprite equippedSprite;           // Sprite untuk tombol "Equipped"
    public Image mainMenuProfileIcon;       // Referensi ke ikon profil di Main Menu
    private int selectedIconIndex = -1;     // Index dari ikon yang dipilih
    private int equippedIconIndex = -1;     // Index dari ikon yang sedang di-equip

    void Start()
    {
        // Menambahkan listener pada tiap tombol untuk memilih ikon
        for (int i = 0; i < iconButtons.Length; i++)
        {
            int index = i;  // Copy index untuk digunakan dalam lambda
            iconButtons[i].onClick.AddListener(() => SelectIcon(index));
        }

        // Menambahkan listener untuk tombol Equip
        equipButton.onClick.AddListener(EquipIcon);

        // Memuat ikon yang dipilih sebelumnya jika ada
        LoadEquippedIcon();
    }

    // Fungsi untuk memilih ikon dan menampilkannya pada preview
    void SelectIcon(int index)
    {
        selectedIconIndex = index;
        previewImage.sprite = profileIcons[index];

        // Cek apakah ikon yang dipilih adalah ikon yang sudah di-equip
        if (selectedIconIndex == equippedIconIndex)
        {
            // Jika ikon sudah di-equip, ubah gambar tombol menjadi "Equipped"
            equipButtonImage.sprite = equippedSprite;
        }
        else
        {
            // Jika ikon berbeda, ubah gambar tombol menjadi "Equip"
            equipButtonImage.sprite = equipSprite;
        }
    }

    // Fungsi untuk menyimpan ikon yang dipilih (equipped)
    void EquipIcon()
    {
        if (selectedIconIndex != -1)
        {
            // Simpan index ikon yang dipilih ke PlayerPrefs
            equippedIconIndex = selectedIconIndex;  // Set ikon yang di-equip
            PlayerPrefs.SetInt("SelectedProfileIcon", selectedIconIndex);
            PlayerPrefs.Save();

            // Update ikon profil di Main Menu
            mainMenuProfileIcon.sprite = profileIcons[selectedIconIndex];

            // Ubah gambar tombol menjadi "Equipped"
            equipButtonImage.sprite = equippedSprite;
        }
    }

    // Fungsi untuk memuat ikon yang dipilih sebelumnya saat game dimulai
    void LoadEquippedIcon()
    {
        if (PlayerPrefs.HasKey("SelectedProfileIcon"))
        {
            equippedIconIndex = PlayerPrefs.GetInt("SelectedProfileIcon");
            previewImage.sprite = profileIcons[equippedIconIndex];
            mainMenuProfileIcon.sprite = profileIcons[equippedIconIndex];  // Pastikan ikon main menu juga terupdate
            selectedIconIndex = equippedIconIndex;  // Pastikan selected index sesuai dengan equipped

            // Ubah gambar tombol menjadi "Equipped"
            equipButtonImage.sprite = equippedSprite;
        }
    }
}
