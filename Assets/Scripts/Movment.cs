using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] CircleCollider2D circleCollider;
    [SerializeField] float movementSpeed = 800f;
    [SerializeField] float jumpForce = 80f;
    [SerializeField] float castDistance = 0.1f;
    [SerializeField] bool isGrounded = true;
    
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector2(horizontal * movementSpeed * Time.deltaTime, rigidBody.velocity.y);

        bool jump = Input.GetButtonDown("Jump");
        if (jump && isGrounded)
        {
            rigidBody.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        Collider2D[] overlapResults = Physics2D.OverlapCircleAll(transform.position + Vector3.down * castDistance, circleCollider.radius);
        isGrounded = false;

        for (int i = 0; i < overlapResults.Length; i++)
        {
            if (overlapResults[i].gameObject != gameObject)
            {
                isGrounded = true;
                break;
            }
        }
    }
}
