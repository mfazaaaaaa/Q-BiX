using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelector : MonoBehaviour
{
    public string selectedMap; // Untuk menyimpan nama scene yang dipilih

    // Fungsi untuk memilih map pertama
    public void SelectMap1()
    {
        selectedMap = "Map1"; // Nama scene Map1
    }

    // Fungsi untuk memilih map kedua
    public void SelectMap2()
    {
        selectedMap = "Map2"; // Nama scene Map2
    }

    // Fungsi untuk meng-load scene yang dipilih
    public void PlaySelectedMap()
    {
        if (!string.IsNullOrEmpty(selectedMap))
        {
            SceneManager.LoadScene(selectedMap); // Load scene yang dipilih
        }
        else
        {
            Debug.Log("No map selected!"); // Debug log jika tidak ada map yang dipilih
        }
    }
}
