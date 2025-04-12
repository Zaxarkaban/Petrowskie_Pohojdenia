using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Interpolate; // Включаем интерполяцию
    }

    void Update()
    {
        // Получаем ввод от пользователя
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Нормализуем вектор движения, чтобы скорость была постоянной
        movement = movement.normalized;
    }

    void FixedUpdate()
    {
        // Перемещаем персонажа
        rb.linearVelocity = movement * moveSpeed;
    }
}