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
<<<<<<< Updated upstream
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //float directionX = Input.GetAxis("Horizontal");
        //float directionY = Input.GetAxis("Vertical");
        //transform.position += new Vector3(Time.deltaTime*moveSpeed, 0);
        if (direction.x != 0 && direction.y != 0)
        {
            direction /= Mathf.Sqrt(2);
        }
        rb.linearVelocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
=======
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
>>>>>>> Stashed changes
    }
}
