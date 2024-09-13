using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource mainmenubgmSource; // AudioSource BGM
    public Button bgmOnButton;    // Tombol untuk menyalakan BGM
    public Button bgmOffButton;   // Tombol untuk mematikan BGM

    private void Start()
    {
        // Assign fungsi ke tombol
        bgmOnButton.onClick.AddListener(TurnOnBGM);
        bgmOffButton.onClick.AddListener(TurnOffBGM);

        // Mulai dengan BGM dalam keadaan aktif
        mainmenubgmSource.Play();
    }

    // Fungsi untuk menyalakan BGM
    void TurnOnBGM()
    {
        if (!mainmenubgmSource.isPlaying)
        {
            mainmenubgmSource.Play();
        }
    }

    // Fungsi untuk mematikan BGM
    void TurnOffBGM()
    {
        if (mainmenubgmSource.isPlaying)
        {
            mainmenubgmSource.Pause();
        }
    }
}
