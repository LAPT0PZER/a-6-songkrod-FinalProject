using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4f;  // ��������㹡���Թ
    public float jumpForce = 8f; // �����ç㹡�á��ⴴ

    [SerializeField]private Rigidbody2D rb;
    [SerializeField]private bool isGrounded; // ��Ǩ�ͺ������躹����������

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // �Ҥ���๹�� Rigidbody2D
    }

    void Update()
    {
        // �Ǻ�������Թ
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // �Ǻ�����á��ⴴ
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // ��ع����Ф� (Flip)
        if (moveInput != 0)
        {
            Flip(moveInput);
        }
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        // ��������躹���������ա�ê��Ѻ�ѵ�ط������ "Ground"
        if (target.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;  // ����Ф����躹���
        }
    }

    private void OnCollisionExit2D(Collision2D target)
    {
        // ����͡�ҡ��������ʾ�� ����������ö���ⴴ��
        if (target.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;  // ����Ф�������躹�������
        }
    }

    private void Flip(float moveInput)
    {
        // ����� localScale �����з�͹����Ф��᡹ X
        if (moveInput > 0 && transform.localScale.x < 0 || moveInput < 0 && transform.localScale.x > 0)
        {
            // ��Ѻ��Ңͧ localScale.x ���� Flip ����Ф�
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
}
