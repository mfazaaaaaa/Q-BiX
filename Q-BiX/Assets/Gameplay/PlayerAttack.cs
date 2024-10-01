using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public int attackDamage = 20; // Damage yang diberikan kepada musuh
    public Collider2D attackCollider; // Collider yang sudah disiapkan di depan pemain
    public Animator animator; // Animator untuk menjalankan animasi serangan

    // Array untuk menampung 3 sound effect untuk setiap jenis serangan
    public AudioClip[] pukulSounds; // 3 sound pukul
    public AudioClip[] tebasSounds; // 3 sound tebas
    public AudioClip[] tusukSounds; // 3 sound tusuk

    private Collider2D[] hitEnemies = new Collider2D[10];
    private bool isAttacking = false; // Menandakan apakah sedang menyerang
    private float attackCooldown = 0.5f; // Durasi cooldown serangan
    private float lastAttackTime = 0f; // Waktu serangan terakhir
    private System.Random random = new System.Random(); // Random number generator

    void Update()
    {
        // Menyerang saat tombol "R" ditekan dan cooldown telah berlalu
        if (Input.GetKeyDown(KeyCode.R) && !isAttacking && Time.time >= lastAttackTime + attackCooldown)
        {
            Attack();
        }
    }

    void Attack()
    {
        isAttacking = true; // Menandakan sedang menyerang
        lastAttackTime = Time.time; // Catat waktu serangan terakhir

        // Cek weapon yang digunakan dan jalankan animasi yang sesuai
        int weaponIndex = PlayerPrefs.GetInt("SelectedWeaponIndex", -1);

        if (weaponIndex == -1)
        {
            animator.SetTrigger("Pukul");
            PlayRandomSound(pukulSounds); // Mainkan sound pukul secara random
        }
        else if (weaponIndex == 0 || weaponIndex == 1 || weaponIndex == 3)
        {
            animator.SetTrigger("Tebas");
            PlayRandomSound(tebasSounds); // Mainkan sound tebas secara random
        }
        else if (weaponIndex == 2)
        {
            animator.SetTrigger("Tusuk");
            PlayRandomSound(tusukSounds); // Mainkan sound tusuk secara random
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

    void PlayRandomSound(AudioClip[] soundArray)
    {
        if (soundArray.Length > 0)
        {
            int randomIndex = random.Next(0, soundArray.Length); // Pilih secara acak
            AudioSource.PlayClipAtPoint(soundArray[randomIndex], transform.position);
        }
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
