using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int attackDamage = 20; // Damage yang diberikan kepada player
    public Collider2D attackCollider; // Collider yang sudah disiapkan di depan musuh
    public float attackRange = 2f; // Jarak serangan musuh
    public float attackInterval = 2f; // Interval waktu antara serangan
    public Transform player; // Referensi untuk posisi player

    private float lastAttackTime = 0f; // Waktu terakhir musuh menyerang

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Serang jika player berada dalam jangkauan serang
        if (distanceToPlayer <= attackRange)
        {
            if (Time.time - lastAttackTime >= attackInterval)
            {
                Attack();
                lastAttackTime = Time.time; // Update waktu terakhir serangan
            }
        }
    }

    void Attack()
    {
        // Membuat filter untuk mendeteksi player (optional)
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter(); // Tidak ada filter khusus, semua collider diperbolehkan

        // Mencari player dalam collider serangan
        Collider2D[] hitPlayers = new Collider2D[10];
        int hitCount = attackCollider.OverlapCollider(filter, hitPlayers);

        // Memproses player yang terkena serangan
        for (int i = 0; i < hitCount; i++)
        {
            Collider2D hitPlayer = hitPlayers[i];

            if (hitPlayer.CompareTag("Player"))
            {
                hitPlayer.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            }
        }
    }
}
