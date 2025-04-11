using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //float directionX = Input.GetAxis("Horizontal");
        //float directionY = Input.GetAxis("Vertical");
        //transform.position += new Vector3(Time.deltaTime*moveSpeed, 0);
        if (direction.x != 0 && direction.y != 0)
        {
            direction /= Mathf.Sqrt(2);
        }
        rb.linearVelocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
    }
}
