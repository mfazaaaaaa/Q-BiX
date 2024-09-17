using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damageAmount = 20;  // Jumlah damage yang diberikan
    public string targetTag = "Enemy";  // Tag target yang bisa menerima damage

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Mengecek apakah objek yang memasuki area memiliki tag yang sesuai
        if (other.CompareTag(targetTag))
        {
            // Mencari komponen Player pada objek
            Player playerComponent = other.GetComponent<Player>();

            if (playerComponent != null)
            {
                playerComponent.TakeDamage(damageAmount);  // Jika objek memiliki komponen Player, panggil fungsi TakeDamage
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider2D>().size);  // Gambar area trigger untuk debugging
    }
}
