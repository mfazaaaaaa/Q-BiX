using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public Image characterPreviewWeapon;   // Objek UI Image untuk weapon di preview menu skin
    public Image mainMenuCharacterWeapon;  // Objek UI Image untuk weapon di tampilan main menu

    public Sprite noWeaponSprite;          // Sprite untuk kondisi tanpa weapon
    public Sprite[] weaponSprites;         // Array sprite weapon

    public Button[] weaponButtons;         // Tombol untuk memilih weapon
    public Button equipButton;             // Tombol untuk mengequip weapon
    public Sprite equipSprite;             // Sprite untuk tombol equip
    public Sprite unequipSprite;           // Sprite untuk tombol unequip

    private Sprite selectedWeapon;         // Weapon yang dipilih
    private Sprite equippedWeapon;         // Weapon yang saat ini di-equip

    void Start()
    {
        // Assign listener ke setiap tombol weapon
        for (int i = 0; i < weaponButtons.Length; i++)
        {
            int index = i;
            weaponButtons[i].onClick.AddListener(() => SelectWeapon(weaponSprites[index]));
        }

        // Listener untuk tombol equip/unequip
        equipButton.onClick.AddListener(ToggleEquipWeapon);

        // Load weapon terakhir yang dipilih
        LoadWeaponPreference();
    }

    // Fungsi untuk memilih weapon
    void SelectWeapon(Sprite weaponSprite)
    {
        selectedWeapon = weaponSprite;

        // Tampilkan weapon yang dipilih di preview karakter
        characterPreviewWeapon.sprite = selectedWeapon;

        // Cek apakah weapon yang dipilih sudah di-equip
        if (selectedWeapon == equippedWeapon)
        {
            // Jika weapon sudah di-equip, tampilkan tombol 'UNEQUIP'
            equipButton.image.sprite = unequipSprite;
        }
        else
        {
            // Jika weapon belum di-equip, tampilkan tombol 'EQUIP'
            equipButton.image.sprite = equipSprite;
        }
    }

    // Fungsi untuk mengequip/unequip weapon ke main menu dan menyimpannya
    void ToggleEquipWeapon()
    {
        if (selectedWeapon != null && mainMenuCharacterWeapon.sprite != selectedWeapon)
        {
            // Equip: Tampilkan weapon yang dipilih di main menu
            mainMenuCharacterWeapon.sprite = selectedWeapon;

            // Simpan weapon yang di-equip
            equippedWeapon = selectedWeapon;

            // Ubah gambar tombol menjadi 'UNEQUIP'
            equipButton.image.sprite = unequipSprite;

            // Simpan weapon yang dipilih
            SaveWeaponPreference();
        }
        else if (selectedWeapon != null && mainMenuCharacterWeapon.sprite == selectedWeapon)
        {
            // Unequip: Kembalikan ke kondisi tanpa weapon
            mainMenuCharacterWeapon.sprite = noWeaponSprite;

            // Hapus weapon yang di-equip
            equippedWeapon = null;

            // Ubah gambar tombol menjadi 'EQUIP'
            equipButton.image.sprite = equipSprite;

            // Hapus weapon yang dipilih dari preference
            PlayerPrefs.DeleteKey("SelectedWeaponIndex");
            PlayerPrefs.Save();

            // Juga kembalikan preview karakter ke noWeaponSprite
            characterPreviewWeapon.sprite = noWeaponSprite;
        }
    }

    // Fungsi untuk menyimpan weapon yang dipilih
    void SaveWeaponPreference()
    {
        // Cek indeks weapon yang dipilih
        int weaponIndex = -1; // -1 untuk tidak ada weapon

        for (int i = 0; i < weaponSprites.Length; i++)
        {
            if (selectedWeapon == weaponSprites[i])
            {
                weaponIndex = i;
                break;
            }
        }

        PlayerPrefs.SetInt("SelectedWeaponIndex", weaponIndex);
        PlayerPrefs.Save();
    }

    // Fungsi untuk memuat weapon terakhir yang dipilih
    void LoadWeaponPreference()
    {
        int weaponIndex = PlayerPrefs.GetInt("SelectedWeaponIndex", -1); // Default tidak ada weapon

        if (weaponIndex >= 0 && weaponIndex < weaponSprites.Length)
        {
            selectedWeapon = weaponSprites[weaponIndex];
            equippedWeapon = selectedWeapon;

            // Tampilkan weapon di preview dan main menu
            characterPreviewWeapon.sprite = selectedWeapon;
            mainMenuCharacterWeapon.sprite = selectedWeapon;

            // Ubah gambar tombol menjadi 'UNEQUIP'
            equipButton.image.sprite = unequipSprite;
        }
        else
        {
            // Jika tidak ada weapon yang dipilih, gunakan sprite noWeapon
            characterPreviewWeapon.sprite = noWeaponSprite;
            mainMenuCharacterWeapon.sprite = noWeaponSprite;

            // Pastikan tombol kembali menjadi 'EQUIP'
            equipButton.image.sprite = equipSprite;
        }
    }
}
