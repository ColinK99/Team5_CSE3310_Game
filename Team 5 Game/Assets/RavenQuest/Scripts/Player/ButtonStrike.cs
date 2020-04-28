using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class ButtonStrike : MonoBehaviour
{
   // public Animator strike;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    private PlayerStats stats;
    public float attackRange;
    private float cooldownTime;
    private Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        cooldownTime = 0;
        stats = GetComponent<PlayerStats>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownTime > 0)
        {
            cooldownTime -= Time.deltaTime;
        }
    }

    public void OnButtonPress()
    {
        if (cooldownTime <=0)
        {
            anim.SetTrigger("attacking");
            cooldownTime = stats.cooldown;
            Attack();
        }

    }
    void Attack()
    {

       Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            // For all overlaps between position located at attackRange, retrieve this collider ID

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyScript>().enemyHit(stats.attack);

        }

        SoundManager.PlaySound("playerStrike");
       // anim.SetBool("attacking", false);
      
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}