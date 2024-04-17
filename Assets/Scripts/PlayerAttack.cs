using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] float damage = 20f;
    public void AttackEvent()
    {
        Collider2D[] overlapResults = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
        foreach(Collider2D enemy in overlapResults)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

        }
    }
}
