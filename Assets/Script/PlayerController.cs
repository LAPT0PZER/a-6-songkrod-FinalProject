using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // ความเร็วในการเดิน
    public float jumpForce = 7f;  // ความแรงในการกระโดด
    public Transform groundCheck; // ตัวตรวจสอบว่าอยู่บนพื้น
    public LayerMask groundLayer; // เลเยอร์ที่ใช้เช็คพื้น

    [SerializeField]private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;

    void Start()
    {
        // รับค่า Rigidbody2D ที่ใช้ในการเคลื่อนที่
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ตรวจสอบการเคลื่อนไหวของผู้เล่น
        moveInput = Input.GetAxis("Horizontal");

        // ตรวจสอบการกระโดด
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        Debug.Log("Is Grounded: " + isGrounded);  // แสดงค่า true หรือ false ใน Console

        // หากผู้เล่นกดปุ่มกระโดดและอยู่บนพื้น
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        // เคลื่อนที่ไปทางซ้ายหรือขวา
        Move();
    }

    void Move()
    {
        // การเคลื่อนที่ในแนวนอน
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        // เพิ่มแรงกระโดด
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
