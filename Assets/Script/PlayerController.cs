using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4f;  // ความเร็วในการเดิน
    public float jumpForce = 8f; // ความแรงในการกระโดด

    [SerializeField]private Rigidbody2D rb;
    [SerializeField]private bool isGrounded; // ตรวจสอบว่าอยู่บนพื้นหรือไม่

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // หาคอมโพเนนต์ Rigidbody2D
    }

    void Update()
    {
        // ควบคุมการเดิน
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // ควบคุมการกระโดด
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // หมุนตัวละคร (Flip)
        if (moveInput != 0)
        {
            Flip(moveInput);
        }
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        // เช็คว่าอยู่บนพื้นเมื่อมีการชนกับวัตถุที่มีแท็ก "Ground"
        if (target.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;  // ตัวละครอยู่บนพื้น
        }
    }

    private void OnCollisionExit2D(Collision2D target)
    {
        // ถ้าออกจากการสัมผัสพื้น ให้ไม่สามารถกระโดดได้
        if (target.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;  // ตัวละครไม่อยู่บนพื้นแล้ว
        }
    }

    private void Flip(float moveInput)
    {
        // การใช้ localScale เพื่อสะท้อนตัวละครในแกน X
        if (moveInput > 0 && transform.localScale.x < 0 || moveInput < 0 && transform.localScale.x > 0)
        {
            // สลับค่าของ localScale.x เพื่อ Flip ตัวละคร
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
}
