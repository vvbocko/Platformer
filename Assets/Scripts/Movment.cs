using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Animator animator;
    [SerializeField] private float radius = 0.5f;
    [SerializeField] private float movementSpeed = 800f;
    [SerializeField] private float jumpForce = 80f;
    [SerializeField] private float castDistance = 0.1f;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private int maxJumps = 1;
    [SerializeField] private int jumpCount;
    private bool isMoving = false;
    private bool isLookingRight = true;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector2(horizontal * movementSpeed * Time.deltaTime, rigidBody.velocity.y);
        
        isMoving = horizontal != 0.0f;
        if(horizontal > 0 && !isLookingRight || horizontal < 0 && isLookingRight)
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1.0f;

            transform.localScale = localScale;
            isLookingRight = !isLookingRight;


        }

        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isGrounded", isGrounded);


        bool jump = Input.GetButtonDown("Jump");
        if (jump)
        {
            if (isGrounded || jumpCount > 0)
            {
                animator.SetTrigger("Jump");
                rigidBody.velocity = new Vector2( rigidBody.velocity.x , jumpForce);
                isGrounded = false;
                jumpCount -= 1;
            }
        }
        bool attack = Input.GetKeyDown(KeyCode.F);
        if (attack) 
        {
            animator.SetTrigger("Attack");
        }
    }

    public void Attack()
    {
        Debug.Log("Attack");
    }

    void FixedUpdate()
    {
        Collider2D[] overlapResults = Physics2D.OverlapCircleAll(transform.position + Vector3.down * castDistance, radius);
        isGrounded = false;

        for (int i = 0; i < overlapResults.Length; i++)
        {
            if (overlapResults[i].gameObject != gameObject)
            {
                isGrounded = true;
                jumpCount = maxJumps;
                break;
            }
        }
    }
}