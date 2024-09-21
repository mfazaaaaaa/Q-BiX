using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public int attackDamage = 20; // Damage yang diberikan kepada player
    public Collider2D attackCollider; // Collider yang sudah disiapkan di depan musuh
    public float attackInterval = 2f; // Interval waktu antara serangan
    public Transform player; // Referensi untuk posisi player
    public Animator animator; // Animator untuk menjalankan animasi serangan

    // Buffer untuk menampung collider player yang terkena serangan
    private Collider2D[] hitPlayers = new Collider2D[10];
    private float lastAttackTime = 0f; // Waktu terakhir musuh menyerang

    void Update()
    {
        // Serang jika waktu antara serangan terakhir terpenuhi
        if (Time.time - lastAttackTime >= attackInterval && !animator.GetBool("IsAttacking"))
        {
            Attack();
            lastAttackTime = Time.time; // Update waktu terakhir serangan
        }
    }

    void Attack()
    {
        // Set IsAttacking ke true untuk memulai animasi serangan
        animator.SetBool("IsAttacking", true);

        // Cek weapon yang digunakan oleh musuh dan jalankan animasi yang sesuai
        int weaponIndex = PlayerPrefs.GetInt("EnemyWeaponIndex", -1);
        Debug.Log("Enemy Weapon Index: " + weaponIndex); // Log untuk debug

        // Pastikan untuk mengatur trigger yang tepat
        if (weaponIndex == -1)
        {
            animator.SetTrigger("Pukul");
            Debug.Log("Trigger Pukul");
        }
        else if (weaponIndex == 0 || weaponIndex == 1 || weaponIndex == 3)
        {
            animator.SetTrigger("Tebas");
            Debug.Log("Trigger Tebas");
        }
        else if (weaponIndex == 2)
        {
            animator.SetTrigger("Tusuk");
            Debug.Log("Trigger Tusuk");
        }

        // Mencari player dalam collider serangan
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter(); // Tidak ada filter khusus, semua collider diperbolehkan

        int hitCount = attackCollider.OverlapCollider(filter, hitPlayers);

        // Memproses player yang terkena serangan
        for (int i = 0; i < hitCount; i++)
        {
            Collider2D hitPlayer = hitPlayers[i];
            if (hitPlayer.CompareTag("Player"))
            {
                hitPlayer.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
                Debug.Log("Player hit for damage: " + attackDamage);
            }
        }

        // Setelah animasi selesai, kembali ke idle
        StartCoroutine(ResetAttack());
    }

    private IEnumerator ResetAttack()
    {
        // Tunggu hingga durasi animasi serangan selesai
        float animationDuration = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationDuration);

        // Kembali ke idle setelah reset
        animator.SetBool("IsAttacking", false); // Mengatur kembali ke idle
    }
}
