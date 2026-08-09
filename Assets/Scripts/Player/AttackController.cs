using UnityEngine;

public class AttackController : MonoBehaviour
{
    public GameObject attackHitbox;
    public float attackCooldown = 0.3f;
    public float attackDuration = 0.15f;

    private float lastAttackTime;

    void Start()
    {
        attackHitbox.SetActive(false);
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