using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Скорость движения
    public float jumpForce = 5f; // Сила прыжка
    private Rigidbody2D rb;      // Ссылка на Rigidbody2D

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Получаем компонент Rigidbody2D
    }

    void Update()
    {
        // Управление движением
        float horizontal = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);

        // Прыжок
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        // Проверка земли с помощью Raycast
        return Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
    }
}
