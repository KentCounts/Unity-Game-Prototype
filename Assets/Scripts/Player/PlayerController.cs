using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    [Header("Animation State Names")]
    [SerializeField] private string idleDownState = "Player_idle_down";
    [SerializeField] private string idleUpState = "Player_idle_up";
    [SerializeField] private string idleLeftState = "Player_idle_left";
    [SerializeField] private string idleRightState = "Player_idle_right";

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;

    private Vector2 lastMoveDirection = Vector2.down;
    private string currentAnimationState;

    private PlayerHealth playerHealth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();

        PlayIdleAnimation(lastMoveDirection);
    }

    void Update()
    {
        if (playerHealth.IsDead())
        {
            movement = Vector2.zero;
            return;
        }

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        movement.Normalize();

        if (movement != Vector2.zero)
        {
            lastMoveDirection = GetCardinalDirection(movement);
            PlayIdleAnimation(lastMoveDirection);
        }
    }

    void FixedUpdate()
    {
        if (playerHealth.IsDead())
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        rb.linearVelocity = movement * moveSpeed;
    }

    public Vector2 GetLastMoveDirection()
    {
        return lastMoveDirection;
    }

    private Vector2 GetCardinalDirection(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            return direction.x > 0 ? Vector2.right : Vector2.left;
        }

        return direction.y > 0 ? Vector2.up : Vector2.down;
    }

    private void PlayIdleAnimation(Vector2 direction)
    {
        if (animator == null)
        {
            return;
        }

        string nextState = idleDownState;

        if (direction == Vector2.up)
        {
            nextState = idleUpState;
        }
        else if (direction == Vector2.left)
        {
            nextState = idleLeftState;
        }
        else if (direction == Vector2.right)
        {
            nextState = idleRightState;
        }

        if (currentAnimationState == nextState)
        {
            return;
        }

        animator.Play(nextState);
        currentAnimationState = nextState;
    }
}
