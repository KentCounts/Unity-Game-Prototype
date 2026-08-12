using UnityEngine;

public class AttackController : MonoBehaviour
{
    public GameObject attackHitbox;
    public float attackCooldown = 0.3f;
    public float attackDuration = 0.15f;
    public float attackDistance = 0.6f;

    public int attackDamage = 1;

    private float lastAttackTime;

    private PlayerController playerController;

    void Start()
    {
        attackHitbox.SetActive(false);
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (Time.time < lastAttackTime + attackCooldown)
        {
            return;
        }

        Vector2 direction = playerController.GetLastMoveDirection();

        attackHitbox.transform.localPosition = direction * attackDistance;

        lastAttackTime = Time.time;

        attackHitbox.SetActive(true);

        Invoke(nameof(EndAttack), attackDuration);

        Debug.Log("Player attacked!");
    }

    private void EndAttack()
    {
        attackHitbox.SetActive(false);
    }
}