using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerStrike, playerHurt, enemyHit, playerJump, playerLose, healthGiven;
    static AudioSource src;

    // Start is called before the first frame update
    // Update is called once per frame
    void Start()
    {
        playerStrike = Resources.Load<AudioClip>("playerStrike");
        playerHurt = Resources.Load<AudioClip>("playerHurt");
        enemyHit = Resources.Load<AudioClip>("enemyHit");
        playerJump = Resources.Load<AudioClip>("playerJump");
        playerLose = Resources.Load<AudioClip>("playerLose");
        healthGiven = Resources.Load<AudioClip>("healthGiven");

        src = GetComponent<AudioSource>();
    }
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "playerHurt":
                src.PlayOneShot(playerHurt);
                break;
            case "healthGiven":
                src.PlayOneShot(healthGiven);
                break;

            case "playerStrike":
                src.PlayOneShot(playerStrike);
                break;
            case "enemyHit":
                src.PlayOneShot(enemyHit);
                break;
            case "playerJump":
                src.PlayOneShot(playerJump);
                break;
           // case "playerLose":
             //   src.PlayOneShot(playerLose);
               // break;
        }
    }

}
