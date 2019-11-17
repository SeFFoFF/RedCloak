using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

    bool dieByThrones = false;
    bool die = false;
    public int life = 3;
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    Animator anim;

    public GameObject healtPotionEffect;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        anim.SetBool("Die", die);
    }

    void Update()
    {
        if (health > numOfHearts)
            health = numOfHearts;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;


            if (i < numOfHearts)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }

        if (life == 0)
        {
            anim.SetBool("Die", true);
            Invoke("ReloadLevel", 2); // Уровень перезагрузится через 1 секунду
            enabledMoving();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            FindObjectOfType<AudioManager>().Play("die");
            health--;
            life--;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "plusHeart")
        {
            numOfHearts++;
            Destroy(collider.gameObject);
        }

        if (collider.gameObject.tag == "life")
        {
            if (life != numOfHearts)
            {
                FindObjectOfType<AudioManager>().Play("takeHealt");
                healtEffect();
                health++;
                life++;
            }
            Destroy(collider.gameObject);
        }

        if (collider.gameObject.tag == "dieCollider")
        {
            FindObjectOfType<AudioManager>().Play("die");
            life = 0;
            health = 0;
        }
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void healtEffect()
    {
        Instantiate(healtPotionEffect, transform.position, Quaternion.identity);
    }

    void enabledMoving()
    {
        this.gameObject.GetComponent<CapsuleCollider2D>().isTrigger = true;

        GameObject hero = GameObject.Find("main_hero");
        HeroControl move = hero.GetComponent<HeroControl>();
        move.enabled = false;

        HeroJump jump = hero.GetComponent<HeroJump>();
        jump.enabled = false;

        HeroAttack attack = hero.GetComponent<HeroAttack>();
        attack.enabled = false;
    }
}
