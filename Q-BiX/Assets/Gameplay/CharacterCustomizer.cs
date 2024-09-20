using UnityEngine;

public class CharacterCustomizer : MonoBehaviour
{
    public SpriteRenderer[] characterParts;   // Bagian tubuh karakter di scene gameplay
    public SpriteRenderer characterAccessory; // Aksesori karakter di scene gameplay
    public SpriteRenderer characterWeapon;    // Weapon karakter di scene gameplay

    public Sprite[] yellowSkinSprites;   // Sprite untuk skin kuning
    public Sprite[] blueSkinSprites;     // Sprite untuk skin biru
    public Sprite[] greenSkinSprites;    // Sprite untuk skin hijau
    public Sprite[] pinkSkinSprites;     // Sprite untuk skin pink
    public Sprite noAccessorySprite;     // Sprite untuk tanpa aksesori
    public Sprite[] accessorySprites;    // Sprite untuk aksesori
    public Sprite noWeaponSprite;        // Sprite untuk tanpa weapon
    public Sprite[] weaponSprites;       // Sprite untuk weapon

    void Start()
    {
        LoadCharacterAttributes();
    }

    void LoadCharacterAttributes()
    {
        // Load skin
        int skinIndex = PlayerPrefs.GetInt("SelectedSkinIndex", 0);
        Sprite[] selectedSkin;
        switch (skinIndex)
        {
            case 1:
                selectedSkin = blueSkinSprites;
                break;
            case 2:
                selectedSkin = greenSkinSprites;
                break;
            case 3:
                selectedSkin = pinkSkinSprites;
                break;
            default:
                selectedSkin = yellowSkinSprites;
                break;
        }

        // Terapkan skin ke karakter di gameplay
        for (int i = 0; i < characterParts.Length; i++)
        {
            characterParts[i].sprite = selectedSkin[i];
        }

        // Load aksesori
        int accessoryIndex = PlayerPrefs.GetInt("SelectedAccessoryIndex", -1);
        if (accessorySprites != null && accessorySprites.Length > 0 && accessoryIndex >= 0 && accessoryIndex < accessorySprites.Length)
        {
            characterAccessory.sprite = accessorySprites[accessoryIndex];
        }
        else
        {
            characterAccessory.sprite = noAccessorySprite;
        }

        // Load weapon
        int weaponIndex = PlayerPrefs.GetInt("SelectedWeaponIndex", -1);
        if (weaponSprites != null && weaponSprites.Length > 0 && weaponIndex >= 0 && weaponIndex < weaponSprites.Length)
        {
            characterWeapon.sprite = weaponSprites[weaponIndex];
        }
        else
        {
            characterWeapon.sprite = noWeaponSprite;
        }
    }
}
