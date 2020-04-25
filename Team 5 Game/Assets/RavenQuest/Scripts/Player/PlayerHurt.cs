using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    PlayerStats playerScript;
    Respawn spawnPoint;
    AutoRespawn tempPoint;
    public int fallDamage = 5;
    private Rigidbody2D body;
    public GameObject enemy;
    public GameObject Damage;
    private SpriteRenderer sprite;
    //public GameObject player;



    /* These values should be stored in some sort of "EnemyStats" 
     * script for easy access
     */
    private EnemyStats enemyStats;  //Delete later
    //Delete Later

    // Update is called once per frame
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playerScript = GetComponent<PlayerStats>();
        spawnPoint = GameObject.FindWithTag("Respawn").GetComponent<Respawn>();
        tempPoint = GameObject.FindWithTag("AutoRespawn").GetComponent<AutoRespawn>();
        sprite = GetComponent<SpriteRenderer>();
     //   enemyStats = GameObject.FindWithTag("Enemy").GetComponent<EnemyStats>();
        // enemy = GameObject.FindWithTag("Enemy");
       //  player = GameObject.FindWithTag("Player");
    }
    void OnTriggerEnter2D(Collider2D target)
    {
         if (target.tag == Damage.tag)
        {
            // Get the stats of that specific object in (Damage) script
            if (playerZero(playerScript.modifyHealth(fallDamage))) //If the player goes over the health ammount they lose
            {
                PlayerLose();
            }
            else
            {
                
                tempPoint.Respawn();

            }
        }
    }

    public void playerHit(int attack, float knockBack)
    {
        // Health change is determined by protected values within PlayerStats

        /*
         *  Determines knockback direction and value for player along with invunerability
         *  timer so the player has time to recover
         *  NOTE: CURRENTLY DOES NOT WORK
         *  */
        if (playerZero(playerScript.modifyHealth(attack)))
        {
            PlayerLose();
        }
        else
        {
           /* if (enemy.transform.position.x > transform.position.x) // If the enemy is to the right of the player
            {
                body.AddForce(5*knockBack * Vector2.left, ForceMode2D.Impulse);
                // Move the player back by the enemy's knockback value in the opposite direction
            }
            else //The enemy is hitting from the left
            {
                body.AddForce(5*knockBack * Vector2.right,ForceMode2D.Impulse);
            }
            */
            sprite.color = Color.red;
            StartCoroutine(Invincible());

        }
    }
    void PlayerLose()
    {
        //Play Defeat animation
     //   GetComponent<Renderer>().enabled = false; //Make player disappear when they "die"

        // Display GameOver Screen

        //if(Continue())
       
        spawnPoint.Spawn(); // Respawn invisible player back to the beginning
        playerScript.resetHealth();// Reset their health
      //  GetComponent<Renderer>().enabled = true;// Then make them reappear and hand over controls to player
        // Else 
        // ExitToMenu

    }

    bool playerZero(int health)
    {
       if(health<=0)
       {
            return true;
       }
       else
        {
            return false;
        }
    }


    IEnumerator Invincible()
    {
        playerScript.Invincible = true;
        yield return new WaitForSeconds(3);
        sprite.color = Color.white;
        playerScript.Invincible = false;
        
    }

}
