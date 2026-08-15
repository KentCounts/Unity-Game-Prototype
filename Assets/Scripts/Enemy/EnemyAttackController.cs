using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    public GameObject attackHitbox;
    public float attackCooldown = 1f;
    public float attackDuration = 0.15f;
    public float attackDistance = 0.6f;

    private float lastAttackTime;

    private Transform player;

    void Start()
    {
        attackHitbox.SetActive(false);

        GameObject playerObject =
            GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        float distanceToPlayer =
            Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackDistance)
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

        Vector2 direction =
            (player.position - transform.position).normalized;

        attackHitbox.transform.localPosition =
            direction * attackDistance;

        attackHitbox.SetActive(true);

        Invoke(nameof(EndAttack), attackDuration);

        Debug.Log("Enemy attacked!");
    }

    private void EndAttack()
    {
        attackHitbox.SetActive(false);
    }
}