using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroJump : MonoBehaviour {

    Animator anim;
    Rigidbody2D rb;

    public float jumpForce = 200f;

    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public bool grounded = false;
    public LayerMask whatIsGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (grounded && Input.GetButtonDown("Jump"))
        {
            anim.SetBool("Ground", false);
            rb.AddForce(new Vector2(0, jumpForce));
        }
            
    }

    void FixedUpdate()
    {
        //bool jump = Input.GetButtonDown("Jump");

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        anim.SetBool("Ground", grounded);
        anim.SetFloat("vSpeed", rb.velocity.y);
    }
}
