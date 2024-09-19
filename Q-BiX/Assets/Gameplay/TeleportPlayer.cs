using UnityEngine;

public class TeleportPlayer: MonoBehaviour
{
    public Transform playerStartPosition;  // Referensi posisi awal player
    public Transform enemyStartPosition;   // Referensi posisi awal musuh

    // Ketika objek memasuki collider
    private void OnTriggerEnter2D(Collider2D other)  // Untuk 2D collider
    {
        // Cek apakah objek yang memasuki collider adalah player
        if (other.CompareTag("Player"))
        {
            other.transform.position = playerStartPosition.position;  // Pindahkan player ke posisi awal
        }

        // Cek apakah objek yang memasuki collider adalah musuh
        if (other.CompareTag("Enemy"))
        {
            other.transform.position = enemyStartPosition.position;  // Pindahkan musuh ke posisi awal
        }
    }

    // Jika menggunakan game 3D, ubah metode OnTriggerEnter2D menjadi OnTriggerEnter seperti ini:
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = playerStartPosition.position;
        }

        if (other.CompareTag("Enemy"))
        {
            other.transform.position = enemyStartPosition.position;
        }
    }
    */
}
