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
    //public GameObject player;
  


    /* These values should be stored in some sort of "EnemyStats" 
     * script for easy access
     */
    public int enemyDmg;  //Delete later
    public int knockBack; //Delete Later

    // Update is called once per frame
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playerScript = GetComponent<PlayerStats>();
        spawnPoint = GameObject.FindWithTag("Respawn").GetComponent<Respawn>();
        tempPoint = GameObject.FindWithTag("AutoRespawn").GetComponent<AutoRespawn>();
        // enemy = GameObject.FindWithTag("Enemy");
       //  player = GameObject.FindWithTag("Player");
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        int health;
        if (target.tag == enemy.tag)
        {
            // Play hurt animation
            health = playerScript.modifyHealth(enemyDmg);
            // Health change is determined by protected values within PlayerStats

            /*
             *  Determines knockback direction and value for player along with invunerability
             *  timer so the player has time to recover
             *  NOTE: CURRENTLY DOES NOT WORK
             *  */
            if (playerZero(health))
            {
                PlayerLose();
            }
            else
            {
                if (enemy.transform.position.x > transform.position.x) // If the enemy is to the right of the player
                {
                    body.AddForce(knockBack * Vector2.left, ForceMode2D.Impulse);
                    // Move the player back by the enemy's knockback value in the opposite direction
                }
                else //The enemy is hitting from the left
                {
                    body.AddForce(knockBack * Vector2.right, ForceMode2D.Impulse);
                }
            }

        }
        else if (target.tag == Damage.tag)
        {
            // Get the stats of that specific object in (Damage) script
            health = playerScript.modifyHealth(fallDamage);
            if (playerZero(health)) //If the player goes over the health ammount they lose
            {
                PlayerLose();
            }
            else
            {
                
                tempPoint.Respawn();

            }
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

}
