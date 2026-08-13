using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float detectionRange = 5f;
    public float stoppingDistance = 1f;

    private Transform player;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

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

        float distanceToPlayer = Vector2.Distance(
            transform.position,
            player.position
        );

        if (distanceToPlayer <= detectionRange &&
            distanceToPlayer > stoppingDistance)
        {
            Vector2 direction = (
                player.position - transform.position
            ).normalized;

            transform.position +=
                (Vector3)direction * moveSpeed * Time.deltaTime;
        }
    }
}