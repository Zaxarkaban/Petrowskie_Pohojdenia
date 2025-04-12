using Unity.VisualScripting;
using UnityEngine;

public class BattleMovement : MonoBehaviour
{
    public float dashDistance = 50f;
    public float dashDuration = 0.2f;
    public float cooldown = 1f;
    public float moveSpeed = 10f;

    private Vector2 dashDirection;
    private bool isDashing = false;
    private bool canDash = true;
    private float dashTimer;
    private float cooldownTimer;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        if (Input.GetKeyDown(KeyCode.Space) && canDash && !isDashing)
        {
            StartDash();
        }

        // Обновляем перезарядку
        if (!canDash)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                canDash = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            dashTimer -= Time.fixedDeltaTime;
            rb.linearVelocity = dashDirection * (dashDistance / dashDuration);

            if (dashTimer <= 0)
            {
                isDashing = false;
            }
        }
        else
        {
            rb.linearVelocity = movement * moveSpeed;
        }
    }

    void StartDash()
    {
        if (movement.magnitude > 0.1f)
        {
            dashDirection = movement.normalized;
            isDashing = true;
            canDash = false;
            dashTimer = dashDuration;
            cooldownTimer = cooldown;
        }
    }
}
