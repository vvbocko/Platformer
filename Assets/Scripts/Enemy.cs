using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;


    // void Update()
    // {
    //     distanceToTarget = Vector2.Distance(transform.position, player.position);
    //     Vector2 direction = player.transform.position - transform.position;
    // }
    private void FixedUpdate()
    {
        Vector2 direction = player.transform.position - transform.position;
        Vector2 directionNormalize = direction.normalized;

        rb.velocity = new Vector2( directionNormalize.x * speed * Time.deltaTime, rb.velocity.y);
    }
}
