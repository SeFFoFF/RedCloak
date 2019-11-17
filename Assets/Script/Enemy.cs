using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;
    public float speed;

    public bool moveLeft;

    private float dazedTime;
    public float startDazedTime;

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hittingWall;

    // Проверка на наличие платформы
    private bool notAtEdge;
    public Transform edgeCheck;

    Rigidbody2D rb;
    Animator anim;
    public GameObject bloodEffect;
    
    bool die_s = false;
    bool hit_s = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetFloat("Speed_s", 1f);
        
    }

    void FixedUpdate()
    {
        anim.SetBool("Die_s", die_s);
        anim.SetBool("Hit_s", hit_s);
    }

    void Update()
    {
        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);
        
        move();

        // Когда получает урон - останавливается
        if (dazedTime <= 0)
            speed = 1f;
        else
        {
            anim.SetBool("Hit_s", true);
            speed = 0.5f;
            dazedTime -= Time.deltaTime;
        }

        // Если 0 жизней - умирает
        if (health <= 0)
        {
            speed = 0f;
            anim.SetBool("Die_s", true);
            Invoke("Death", 2.35f);
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }

    void Blood()
    {
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
    }

    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        Invoke("Blood", 1f);
        health -= damage;
    }

    void move()
    {
        if (hittingWall || !notAtEdge)
            moveLeft = !moveLeft;

        if (moveLeft)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }
}


