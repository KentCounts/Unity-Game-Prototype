using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    private Vector2 lastMoveDirection = Vector2.down;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        movement.Normalize();

        if (movement != Vector2.zero)
        {
            lastMoveDirection = movement;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
    }

    public Vector2 GetLastMoveDirection()
    {
        return lastMoveDirection;
    }
}