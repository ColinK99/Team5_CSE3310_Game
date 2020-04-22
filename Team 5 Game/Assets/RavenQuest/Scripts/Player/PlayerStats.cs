using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public GameObject healthSet;
    HealthBar health;
    private int healthMax = 10;
    public int attack = 5;
    private int level = 1;
    public float speed = 3;
    public int jumpHeight = 10;
    public int knockBack = 2;
    public float attackRange = 0.3f;
    private int nextLevel = 100;
    private int currXP = 0;
    private int currHealth = 10;
    

    void Start()
    {
        health = healthSet.GetComponent<HealthBar>();
    }
    void modifyXp(int amount) // Anytime an enemy is defeated use this function
    {
        currXP += amount;
        if(currXP >= nextLevel) 
        {
            currXP = currXP - nextLevel;
            level++;
            nextLevel = calculateXP(level,nextLevel);

            levelUp();
            // Level- Up screen is displayed. Passing the game to allow player to allocate skills
        }
    }

    int getLevel()
    {
        return level;
    }

    public void resetCharacter() // Default values of the player, reset on new game request
    {
        healthMax = 10;
        attack = 5;
        level = 1;
        nextLevel = 100;
        currXP = 0;
        currHealth = 10;
        attackRange = 0.3f;
        knockBack = 2;
    }
    // Upon defeat reset slider to max health, and stats to max health
    public void resetHealth()
    {
        currHealth = healthMax;
        health.SetMaxHealth(healthMax);

    }

    //If damage is to be taken, return the health left to be compared by a different function
    public int modifyHealth(int damage = 0)
    {
        currHealth -= damage;
        health.SetHealth(currHealth);
        return currHealth;

    }


    // XP is calculated exponentially for the next level,
     int calculateXP(int level, int nextLevel) 
    {
        int rounded = (int) Mathf.Exp(level + 4);

       return rounded + nextLevel;

    }


    void levelUp()
    {

    }



}
