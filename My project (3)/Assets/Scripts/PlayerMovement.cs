using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    private float direction;

    public float jumpForce;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;
    private bool isGrounded;

    private SpriteRenderer sr;

    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        sr = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();
    }


    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (rb.velocity.x < 0)
        {
            sr.flipX = true;
        }
        else if (rb.velocity.x > 0)
        {
            sr.flipX = false;
        }

        anim.SetFloat("moveSpeed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }

}
