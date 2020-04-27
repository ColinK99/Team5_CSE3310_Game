using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPotion : MonoBehaviour
{
    public GameObject player;
    public PlayerStats playerStats;
    public int potionValue = 2;

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == player.tag)
        {
            playerStats.modifyHealth(-1 * potionValue);
            SoundManager.PlaySound("healthGiven");
            Destroy(gameObject);
        }
    }
}
