using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public int attackDamage = 20; // Damage yang diberikan kepada musuh
    public Collider2D attackCollider; // Collider yang sudah disiapkan di depan pemain
    public Animator animator; // Animator untuk menjalankan animasi serangan

    // Buffer untuk menampung collider musuh yang terkena serangan
    private Collider2D[] hitEnemies = new Collider2D[10];
    private bool isAttacking = false; // Menandakan apakah sedang menyerang

    void Update()
    {
        // Menyerang saat tombol "R" ditekan
        if (Input.GetKeyDown(KeyCode.R) && !isAttacking)
        {
            Attack();
        }
    }

    void Attack()
    {
        isAttacking = true; // Menandakan sedang menyerang

        // Cek weapon yang digunakan dan jalankan animasi yang sesuai
        int weaponIndex = PlayerPrefs.GetInt("SelectedWeaponIndex", -1);

        if (weaponIndex == -1)
        {
            animator.SetTrigger("Pukul");
        }
        else if (weaponIndex == 0 || weaponIndex == 1 || weaponIndex == 3)
        {
            animator.SetTrigger("Tebas");
        }
        else if (weaponIndex == 2)
        {
            animator.SetTrigger("Tusuk");
        }

        // Memproses collider serangan
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter(); // Tidak ada filter khusus, semua collider diperbolehkan
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

        // Setelah animasi selesai, kembali ke idle
        StartCoroutine(ResetAttack());
    }

    private IEnumerator ResetAttack()
    {
        // Tunggu hingga animasi selesai (ganti dengan durasi animasi jika perlu)
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        isAttacking = false; // Reset flag menyerang

        // Reset parameter trigger
        animator.ResetTrigger("Pukul");
        animator.ResetTrigger("Tebas");
        animator.ResetTrigger("Tusuk");
    }
}
