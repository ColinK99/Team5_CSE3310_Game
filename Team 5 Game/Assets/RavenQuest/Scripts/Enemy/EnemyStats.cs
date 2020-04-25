using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    
    private int healthMax = 10;
    private int currHealth = 10;
    public int attack = 5;
    public float aggroRange = 4;
    public float stopRange = 0.4f;
    public float attackRange = 0.3f;
    public float knockBack = 10;
    public float moveSpeed = 0.5f;
    public float cooldown = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public int modifyHealth(int damage = 0)
    {
        currHealth -= damage;
        return currHealth;

    }
    public int getMax()
    {
        return healthMax;
    }

    public void resetHealth()
    {
        currHealth = healthMax;

    }

}
