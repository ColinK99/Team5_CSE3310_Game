using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStrike : MonoBehaviour
{
   // public Animator strike;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    private EnemyScript enemyHurt;
    private PlayerStats stats;


    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<PlayerStats>();
        enemyHurt = GameObject.FindWithTag("Enemy").GetComponent<EnemyScript>();
    }

    // Update is called once per frame

    public void OnButtonPress()
    {
        Attack();
        
    }

    void Attack()
    {
        // Play Attack Animation 
        // strike.SetTrigger("Strike");
      Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,stats.attackRange,enemyLayers);
        // For all overlaps between position located at attackRange, retrieve this collider ID

      foreach(Collider2D enemy in hitEnemies)
      {
            enemyHurt.enemyHit(stats.attack,stats.knockBack);
            Debug.Log("Enemy " + enemy.name + "Hit");
      }

    }



}