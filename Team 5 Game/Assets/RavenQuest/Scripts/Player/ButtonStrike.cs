using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStrike : MonoBehaviour
{
   // public Animator strike;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRange;

    // Start is called before the first frame update
    void Start()
    {
        attackRange = GetComponent<PlayerStats>().attackRange;
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
      Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);
        // For all overlaps between position located at attackRange, retrieve this collider ID

      foreach(Collider2D enemy in hitEnemies)
      {
         Debug.Log("Hi");
      }

    }


    void OnDrawGizmosSelected()
    {
        // Shows visible representation of attackRange
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}