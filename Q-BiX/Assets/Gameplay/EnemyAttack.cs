using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public int attackDamage = 20; // Damage yang diberikan kepada player
    public Collider2D attackCollider; // Collider yang sudah disiapkan di depan musuh
    public float attackInterval = 2f; // Interval waktu antara serangan
    public Transform player; // Referensi untuk posisi player
    public Animator animator; // Animator untuk menjalankan animasi serangan

    public int weaponIndex; // Indeks senjata yang dipilih dari EnemyCustomizer

    // Buffer untuk menampung collider player yang terkena serangan
    private Collider2D[] hitPlayers = new Collider2D[10];
    private float lastAttackTime = 0f; // Waktu terakhir musuh menyerang
    private bool isAttacking = false;  // Status apakah musuh sedang menyerang

    void Update()
    {
        // Cek apakah player ada dalam jangkauan
        if (IsPlayerInRange())
        {
            if (Time.time - lastAttackTime >= attackInterval && !isAttacking)
            {
                Attack();
                lastAttackTime = Time.time; // Update waktu terakhir serangan
            }
        }
        else
        {
            StopAttackAnimations(); // Hentikan animasi serangan jika player keluar jangkauan
        }
    }

    void Attack()
    {
        isAttacking = true; // Set status menyerang
        animator.SetBool("IsAttacking", true); // Aktifkan animasi menyerang

        // Memilih animasi berdasarkan senjata
        if (weaponIndex == -1)  // Jika tidak ada senjata atau 'NoWeapon'
        {
            animator.SetTrigger("Pukul");  // Animasi memukul
            Debug.Log("Trigger Pukul (No Weapon)");
        }
        else if (weaponIndex == 0 || weaponIndex == 1 || weaponIndex == 3)  // Weapon Index 0, 1, atau 3
        {
            animator.SetTrigger("Tebas");  // Animasi menebas
            Debug.Log("Trigger Tebas");
        }
        else if (weaponIndex == 2)  // Weapon Index 2
        {
            animator.SetTrigger("Tusuk");  // Animasi menusuk
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

        // Setelah serangan selesai, reset status menyerang
        StartCoroutine(ResetAttack());
    }

    IEnumerator ResetAttack()
    {
        // Tunggu sedikit waktu sebelum reset status serangan
        yield return new WaitForSeconds(0.1f);
        isAttacking = false; // Reset status menyerang
        animator.SetBool("IsAttacking", false); // Nonaktifkan animasi menyerang
    }

    bool IsPlayerInRange()
    {
        // Cek apakah player ada di dalam attack collider
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter(); // Tidak ada filter khusus

        int hitCount = attackCollider.OverlapCollider(filter, hitPlayers);

        for (int i = 0; i < hitCount; i++)
        {
            if (hitPlayers[i].CompareTag("Player"))
            {
                return true; // Ada player dalam jangkauan
            }
        }

        return false; // Tidak ada player dalam jangkauan
    }

    void StopAttackAnimations()
    {
        // Reset semua trigger serangan dan hentikan animasi serangan
        animator.ResetTrigger("Pukul");
        animator.ResetTrigger("Tebas");
        animator.ResetTrigger("Tusuk");
        animator.SetBool("IsAttacking", false); // Nonaktifkan animasi serangan
        isAttacking = false; // Pastikan status menyerang juga di-reset
        Debug.Log("Stopping attack animations");
    }
}
