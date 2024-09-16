using UnityEngine;
using UnityEngine.UI;

public class AccessoryManager : MonoBehaviour
{
    public Image characterPreviewAccessory;  // Objek UI Image untuk aksesori di preview menu skin
    public Image mainMenuCharacterAccessory; // Objek UI Image untuk aksesori di tampilan main menu

    public Sprite noAccessorySprite;         // Sprite untuk kondisi tanpa aksesori
    public Sprite[] accessorySprites;        // Array sprite aksesori (misalnya topi, mahkota, dll.)

    public Button[] accessoryButtons;        // Tombol untuk memilih aksesori
    public Button equipButton;               // Tombol untuk mengequip/unequip aksesori

    public Sprite equipButtonSprite;         // Gambar tombol equip
    public Sprite unequipButtonSprite;       // Gambar tombol unequip

    private Sprite selectedAccessory;        // Aksesori yang dipilih
    private bool isEquipped = false;         // Status apakah aksesori sudah di-equip

    void Start()
    {
        // Assign listener ke setiap tombol aksesori
        accessoryButtons[0].onClick.AddListener(() => SelectAccessory(accessorySprites[0])); // Aksesori pertama
        accessoryButtons[1].onClick.AddListener(() => SelectAccessory(accessorySprites[1])); // Aksesori kedua
        accessoryButtons[2].onClick.AddListener(() => SelectAccessory(accessorySprites[2])); // Aksesori ketiga
        accessoryButtons[3].onClick.AddListener(() => SelectAccessory(accessorySprites[3])); // Aksesori keempat
        accessoryButtons[4].onClick.AddListener(() => SelectAccessory(accessorySprites[4])); // Aksesori kelima

        // Listener untuk tombol equip/unequip
        equipButton.onClick.AddListener(ToggleEquipAccessory);

        // Load aksesori terakhir yang dipilih
        LoadAccessoryPreference();
    }

    // Fungsi untuk memilih aksesori
    void SelectAccessory(Sprite accessorySprite)
    {
        selectedAccessory = accessorySprite;

        // Tampilkan aksesori yang dipilih di preview karakter
        characterPreviewAccessory.sprite = selectedAccessory;

        // Jika aksesori baru dipilih, set tombol ke "equip" mode
        equipButton.GetComponent<Image>().sprite = equipButtonSprite;
        isEquipped = false;
    }

    // Fungsi untuk toggle antara equip dan unequip aksesori
    void ToggleEquipAccessory()
    {
        if (isEquipped)
        {
            // Jika sudah di-equip, maka unequip aksesori
            characterPreviewAccessory.sprite = noAccessorySprite;
            mainMenuCharacterAccessory.sprite = noAccessorySprite;

            // Ubah tombol kembali ke "equip"
            equipButton.GetComponent<Image>().sprite = equipButtonSprite;
            isEquipped = false;

            // Simpan status tanpa aksesori
            SaveAccessoryPreference(noAccessorySprite);
        }
        else
        {
            // Jika belum di-equip, maka equip aksesori yang dipilih
            if (selectedAccessory != null)
            {
                characterPreviewAccessory.sprite = selectedAccessory;
                mainMenuCharacterAccessory.sprite = selectedAccessory;

                // Ubah tombol menjadi "unequip"
                equipButton.GetComponent<Image>().sprite = unequipButtonSprite;
                isEquipped = true;

                // Simpan aksesori yang dipilih
                SaveAccessoryPreference(selectedAccessory);
            }
        }
    }

    // Fungsi untuk menyimpan aksesori yang dipilih
    void SaveAccessoryPreference(Sprite accessory)
    {
        int accessoryIndex = -1; // -1 untuk tidak ada aksesori

        for (int i = 0; i < accessorySprites.Length; i++)
        {
            if (accessory == accessorySprites[i])
            {
                accessoryIndex = i;
                break;
            }
        }

        PlayerPrefs.SetInt("SelectedAccessoryIndex", accessoryIndex);
        PlayerPrefs.Save();
    }

    // Fungsi untuk memuat aksesori terakhir yang dipilih
    void LoadAccessoryPreference()
    {
        int accessoryIndex = PlayerPrefs.GetInt("SelectedAccessoryIndex", -1); // Default tidak ada aksesori

        if (accessoryIndex >= 0 && accessoryIndex < accessorySprites.Length)
        {
            selectedAccessory = accessorySprites[accessoryIndex];

            // Tampilkan aksesori di preview dan main menu
            characterPreviewAccessory.sprite = selectedAccessory;
            mainMenuCharacterAccessory.sprite = selectedAccessory;

            // Ubah tombol menjadi "unequip"
            equipButton.GetComponent<Image>().sprite = unequipButtonSprite;
            isEquipped = true;
        }
        else
        {
            // Jika tidak ada aksesori yang dipilih, gunakan sprite noAccessory
            characterPreviewAccessory.sprite = noAccessorySprite;
            mainMenuCharacterAccessory.sprite = noAccessorySprite;

            // Set tombol ke kondisi "equip"
            equipButton.GetComponent<Image>().sprite = equipButtonSprite;
            isEquipped = false;
        }
    }
}
