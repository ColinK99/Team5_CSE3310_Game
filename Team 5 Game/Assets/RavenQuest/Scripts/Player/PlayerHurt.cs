using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHurt : MonoBehaviour
{
    PlayerStats playerScript;
    AutoRespawn tempPoint;
    public int fallDamage = 5;
    private Respawn spawnPoint;
    public GameObject Damage;
    private SpriteRenderer sprite;

    // Update is called once per frame
    void Start()
    {
        this.gameObject.SetActive(true);
        spawnPoint = GameObject.FindWithTag("Respawn").GetComponent<Respawn>();
        playerScript = GetComponent<PlayerStats>();
        tempPoint = GameObject.FindWithTag("AutoRespawn").GetComponent<AutoRespawn>();
        sprite = GetComponent<SpriteRenderer>();

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

    public void playerHit(int attack)
    {
        // Health change is determined by protected values within PlayerStats
       
        if (playerZero(playerScript.modifyHealth(attack)))
        {
            PlayerLose();
        }
        else
        {
            SoundManager.PlaySound("playerHurt");
            sprite.color = Color.red;
            StartCoroutine(Invincible());

        }
    }
    void PlayerLose()
    {

        GameOverMainMenu();

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
        yield return new WaitForSeconds(2);
        sprite.color = Color.white;
        playerScript.Invincible = false;
        
    }

    public void GameOverMainMenu()
    {
        SceneManager.LoadScene("Game Over", LoadSceneMode.Single);
        this.gameObject.SetActive(false);
        spawnPoint.Spawn(); // Respawn invisible player back to the beginning
        playerScript.resetHealth();// Reset their health
                                   //  SoundManager.PlaySound("playerLose");
    }

}
