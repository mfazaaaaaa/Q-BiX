using UnityEngine;

using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private float speed = 5f;  // Kecepatan musuh
    private float jumpingPower = 9f;  // Kekuatan lompat musuh
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform player;  // Referensi untuk posisi player
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Update()
    {
        FollowPlayer();  // Panggil fungsi untuk mengikuti player
        Flip();  // Panggil fungsi untuk membalik arah musuh
    }

    private void FollowPlayer()
    {
        float distanceToPlayerX = player.position.x - transform.position.x;
        float distanceToPlayerY = player.position.y - transform.position.y;

        // Gerak horizontal mengejar player
        rb.velocity = new Vector2(Mathf.Sign(distanceToPlayerX) * speed, rb.velocity.y);

        // Jika player ada di atas dan musuh berada di tanah, musuh akan melompat
        if (IsGrounded() && distanceToPlayerY > 1f)  // Player lebih tinggi dari musuh
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);  // Lompat ke atas
        }
    }

    private void FixedUpdate()
    {
        // Kontrol kecepatan gerak horizontal di FixedUpdate agar pergerakan smooth
        rb.velocity = new Vector2(Mathf.Sign(player.position.x - transform.position.x) * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        // Cek apakah musuh sedang berada di tanah menggunakan OverlapCircle
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        // Membalik arah musuh jika player berada di sisi yang berlawanan
        if (isFacingRight && player.position.x < transform.position.x || !isFacingRight && player.position.x > transform.position.x)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
