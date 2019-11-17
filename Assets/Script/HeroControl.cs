using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroControl : MonoBehaviour {

    Animator anim;
    Rigidbody2D rb;

    public GameObject EndOfLvlMenu;

    public float speed = 5f;

    bool facingRight = true;
    bool die = false;

    void Start()
    {
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Play("bgMusic");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));

        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (move > 0 && !facingRight)
            flip();
        else if (move < 0 && facingRight)
            flip();

        //anim.SetBool("Die", die);
    }

    // Поворот персонажа, когда идёт в другую сторону
    private void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    
    // Взаимодействие с "тригерными" объектами
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "finishCollider")
        {
            FindObjectOfType<AudioManager>().Play("finishLvl");
            EndOfLvlMenu.SetActive(true);
            Time.timeScale = 0f;
        }
           
    }
}

