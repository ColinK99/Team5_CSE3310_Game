using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //all of these values can be adjusted in an enemy object with this script
    private EnemyStats enemy;

    public Transform attackPoint;
    //to assign what the enemy will drop. drag the object that you want the enemy to drop to this field 
    public GameObject drop;

    //to select the player you need to drag the player object into the field
    //this will be used so the enemy can check their distance to the player
    private Transform player;
    public LayerMask playerLayer;
    
    //this next object is the hitbox of the players weapon. to set this you need to drag the AttackBox object under player 
    //into this field under an enemy with this script

    //This will be used to determine how much damage the player does
  
    
    //set rigidbody so the enemy can move
    private Rigidbody2D rb2d;

    //This will be used to set the color of the enemy to red when health is low
    private SpriteRenderer bar;
    //Thisd will be used to set animation booleans
    public Animator anim;
    public float attackRange;
    private PlayerStats playerHealth;
    private PlayerHurt hurt;
    int health;
    private IEnumerator enemyCooldown;



    void Start()
    {
        //set all of the components we need to their variables
        bar = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        enemy = GetComponent<EnemyStats>();
        health = enemy.modifyHealth();
        hurt = GameObject.FindWithTag("Player").GetComponent<PlayerHurt>();

    }


    void Update()
    {
        //This will determine between the enemy and the player
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        //if player is within the aggro range but also not close enough to attack then 
        //walk animation needs to be set to true and the chaseplayer function will be called
        //to set the enemy movement variables
        if ((distToPlayer < enemy.aggroRange) && (distToPlayer > enemy.stopRange) && Mathf.Abs(transform.position.x - player.position.x) >= .1)
        {
             anim.SetBool("Attack", false);
             anim.SetBool("canWalk", true);
             ChasePlayer();

        }
        else if(distToPlayer <= enemy.stopRange)
        {
            rb2d.velocity = new Vector2(0, 0);
            anim.SetBool("canWalk", false);
            anim.SetBool("Attack", true);
            enemyCooldown = Cooldown(enemy.cooldown);
            StartCoroutine(enemyCooldown);
            
       
 
        }
        //if the enemy is close enough to the player the enemy will stop moving and walk animation
        //then the enemy will start the attack animation
        //else the character is not within range for the enemy to do anything so it will set both attack and walk animations to false
        //which should trigger the idle animation the start again
        else
        {
            rb2d.velocity = new Vector2(0, 0);
            anim.SetBool("canWalk", false);
            anim.SetBool("Attack", false);
        }


        //this will set the character of the sprite to red if it is less than or equal to 20
        if (health <= 0.2*(float)(enemy.getMax()))
        {
            bar.color = Color.red;
        }

        //if the enemy health drops to 0 or below then it will be destroyed
        if (health <= 0)
        {
            StopCoroutine(enemyCooldown);
            Instantiate(drop, transform.position, drop.transform.rotation);
            Destroy(gameObject);
        }


    }


    //This function will determine if the enemy has been hit by an attack
    public void enemyHit(int playerDamage)
    {
        health=enemy.modifyHealth(playerDamage);
        
       
    }

    //This is fucntion that will set the movement speed of the enemy if the player is within range 
    void ChasePlayer()
    {
        //if the player is to the right of the enemy then movement should be positive
        //and the sprite should be flipped to face the right
        if (transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(enemy.moveSpeed, 0);
            transform.localScale = new Vector2(3, 3);
        }
        //Else the player is to the left so the enemy movement should be negative
        //and the sprite should be flipped to face the left
        else
        {
            rb2d.velocity = new Vector2(enemy.moveSpeed*-1, 0);
            transform.localScale = new Vector2(-3, 3);
        }
    }

    void attackPlayer()
    {
        Collider2D hitPlayer = Physics2D.OverlapCircle(attackPoint.position, attackRange,playerLayer);
        if (hitPlayer == null)
            return;
        if (hitPlayer.tag == GameObject.FindWithTag("Player").GetComponent<Collider2D>().tag && playerHealth.Invincible==false)
        {

            hurt.playerHit(enemy.attack);
        }


    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    IEnumerator Cooldown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        attackPlayer();
    }

}



