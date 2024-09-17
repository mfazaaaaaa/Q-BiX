using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int attackDamage = 20; // Damage yang diberikan kepada musuh
    public Collider2D attackCollider; // Collider yang sudah disiapkan di depan pemain

    // Buffer untuk menampung collider musuh yang terkena serangan
    private Collider2D[] hitEnemies = new Collider2D[10];

    void Update()
    {
        // Menyerang saat tombol "R" ditekan
        if (Input.GetKeyDown(KeyCode.R))
        {
            Attack();
        }
    }

    void Attack()
    {
        // Membuat filter untuk mendeteksi musuh dengan layer tertentu (optional)
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter(); // Tidak ada filter khusus, semua collider diperbolehkan

        // Mencari musuh dalam collider serangan
        int hitCount = attackCollider.OverlapCollider(filter, hitEnemies);

        // Memproses setiap musuh yang terkena serangan
        for (int i = 0; i < hitCount; i++)
        {
            Collider2D enemy = hitEnemies[i];

            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            }
        }
    }
}
