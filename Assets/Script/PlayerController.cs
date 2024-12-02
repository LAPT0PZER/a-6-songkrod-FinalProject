using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // ��������㹡���Թ
    public float jumpForce = 7f;  // �����ç㹡�á��ⴴ
    public Transform groundCheck; // ��ǵ�Ǩ�ͺ������躹���
    public LayerMask groundLayer; // ������������社��

    [SerializeField]private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;

    void Start()
    {
        // �Ѻ��� Rigidbody2D �����㹡������͹���
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ��Ǩ�ͺ�������͹��Ǣͧ������
        moveInput = Input.GetAxis("Horizontal");

        // ��Ǩ�ͺ��á��ⴴ
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        Debug.Log("Is Grounded: " + isGrounded);  // �ʴ���� true ���� false � Console

        // �ҡ�����蹡��������ⴴ������躹���
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        // ����͹���价ҧ�������͢��
        Move();
    }

    void Move()
    {
        // �������͹�����ǹ͹
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        // �����ç���ⴴ
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
