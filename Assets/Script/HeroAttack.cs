using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour {

    private float timeAttack;
    public float startTimeAttack;

    public Transform attackPos;
    public float attackRange;

    public LayerMask whatIsEnemies;
    public int damage;

    public float attackRangeX;
    public float attackRangeY;


    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (timeAttack >= 0) // когда можно атаковать
        {
            if (Input.GetKeyDown(KeyCode.K) && Input.GetAxis("Horizontal") == 0)
            {
                FindObjectOfType<AudioManager>().Play("playerAttack");
                anim.SetTrigger("Attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
            }
            timeAttack = startTimeAttack;
        }
        else
            timeAttack -= Time.deltaTime;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }

}
