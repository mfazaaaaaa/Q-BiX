using UnityEngine;

public class EnemyCustomizer : MonoBehaviour
{
    public SpriteRenderer[] enemyParts;  // Bagian tubuh musuh yang bisa diubah skinnya
    public SpriteRenderer enemyAccessory;  // Aksesori musuh
    public SpriteRenderer enemyWeapon;     // Senjata musuh

    // Daftar skin yang terdiri dari beberapa bagian tubuh
    public Sprite[] yellowSkinSprites;   // Skin kuning
    public Sprite[] blueSkinSprites;     // Skin biru
    public Sprite[] greenSkinSprites;    // Skin hijau
    public Sprite[] pinkSkinSprites;     // Skin pink

    public Sprite[] accessoryOptions;    // Pilihan aksesori
    public Sprite[] weaponOptions;       // Pilihan senjata

    void Start()
    {
        RandomizeEnemy();
    }

    void RandomizeEnemy()
    {
        // Memilih skin acak
        int randomSkinIndex = Random.Range(0, 4);  // Ada 4 opsi skin: kuning, biru, hijau, pink
        Sprite[] selectedSkin;

        switch (randomSkinIndex)
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

        // Terapkan skin ke setiap bagian tubuh musuh
        for (int i = 0; i < enemyParts.Length; i++)
        {
            enemyParts[i].sprite = selectedSkin[i];
        }

        // Memilih aksesori acak
        if (accessoryOptions.Length > 0)
        {
            Sprite randomAccessory = accessoryOptions[Random.Range(0, accessoryOptions.Length)];
            enemyAccessory.sprite = randomAccessory;
        }

        // Memilih senjata acak
        if (weaponOptions.Length > 0)
        {
            Sprite randomWeapon = weaponOptions[Random.Range(0, weaponOptions.Length)];
            enemyWeapon.sprite = randomWeapon;
        }
    }
}
