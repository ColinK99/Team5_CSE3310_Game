using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class ButtonStrike : MonoBehaviour
{
   // public Animator strike;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    private EnemyScript enemyHurt;
    private PlayerStats stats;
    public float attackRange;
    private float cooldownTime;



    // Start is called before the first frame update
    void Start()
    {
        cooldownTime = 0;
        stats = GetComponent<PlayerStats>();
        enemyHurt = GameObject.FindWithTag("Enemy").GetComponent<EnemyScript>();
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
            enemyHurt.enemyHit(stats.attack);

        }

        SoundManager.PlaySound("playerStrike");
      
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}