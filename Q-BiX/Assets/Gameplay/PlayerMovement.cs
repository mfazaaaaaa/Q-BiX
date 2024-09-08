using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 20f;
    public LayerMask groundLayer;  // Gunakan layer ground untuk mendeteksi tanah

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Mendapatkan input dari pemain untuk gerakan
        movement.x = Input.GetAxisRaw("Horizontal");

        // Memeriksa apakah player berada di tanah menggunakan raycast
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);
        Debug.Log("Grounded: " + isGrounded); // Debugging untuk melihat apakah player terdeteksi di tanah

        // Jika tombol lompat ditekan dan player berada di tanah, lompat
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("Jump pressed!"); // Tambahkan log untuk melihat jika input lompat terdeteksi
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        // Menggerakkan karakter
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}