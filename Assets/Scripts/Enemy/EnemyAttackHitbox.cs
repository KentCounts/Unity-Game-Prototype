using UnityEngine;

public class EnemyAttackHitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Enemy attack hit the player!");
        }
    }
}