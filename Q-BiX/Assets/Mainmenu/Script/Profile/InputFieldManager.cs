using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{
    public InputField playerNameInput; // InputField untuk menerima input dari user
    public GameObject targetObject;    // Objek yang akan diaktifkan/non-aktifkan

    void Start()
    {
        // Pastikan objek dalam keadaan non-aktif saat awal
        targetObject.SetActive(false);

        // Tambahkan listener untuk mendeteksi perubahan pada InputField
        playerNameInput.onValueChanged.AddListener(CheckInput);
    }

    // Fungsi untuk memeriksa input dan mengatur status aktif/non-aktif
    void CheckInput(string input)
    {
        // Jika ada input, aktifkan objek; jika tidak, non-aktifkan
        if (!string.IsNullOrEmpty(input))
        {
            targetObject.SetActive(true);
        }
        else
        {
            targetObject.SetActive(false);
        }
    }
}
