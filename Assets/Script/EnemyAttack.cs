using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    //private float timeAttack;
    //public float startTimeAttack;

    public Transform attackPos;
    public float attackRange;

    public LayerMask whatIsHero;
    public int damage;

    public float attackRangeX;
    public float attackRangeY;
    
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    /*
    void OnTriggerEnter2D(Collider2D collider)
    {
        //if (timeAttack >= 0)
        //{
            if (collider.gameObject.tag == "Player")
            {
                anim.SetTrigger("Attack_s");
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsHero);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
            }
        //    timeAttack = startTimeAttack;
        //}
        //else
        //    timeAttack -= Time.deltaTime;
    }
    */
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }
}
