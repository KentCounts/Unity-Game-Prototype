using UnityEngine;

public class AttackController : MonoBehaviour
{
    public float attackRange = 1f;
    public float attackCooldown = 0.3f;

    private float lastAttackTime;

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

        Debug.Log("Player attacked!");
    }
}