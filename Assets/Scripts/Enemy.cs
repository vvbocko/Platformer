using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;

    public void SetTarget(Transform target)
    {
        player = target;
    }


    // void Update()
    // {
    //     distanceToTarget = Vector2.Distance(transform.position, player.position);
    //     Vector2 direction = player.transform.position - transform.position;
    // }
    private void FixedUpdate()
    {
        if (player == null)
        {
            return;
        }
        Vector2 direction = player.transform.position - transform.position;
        Vector2 directionNormalize = direction.normalized;

        rb.velocity = new Vector2( directionNormalize.x * speed * Time.deltaTime, rb.velocity.y);
    }
}
