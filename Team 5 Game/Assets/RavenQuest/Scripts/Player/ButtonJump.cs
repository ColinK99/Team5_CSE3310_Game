using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonJump : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D playerBody;
    private Transform playerPos;
    private Collider2D playerFeet;
   // public Animator jump;
    public LayerMask platform;
    public float touchDistance;
    private float groundDist;

    PlayerStats playerStats;
    
    // Update is called once per frame
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        playerFeet = GetComponent<Collider2D>();
        playerBody = GetComponent<Rigidbody2D>();
        playerPos =  GetComponent<Transform>();
        groundDist = playerFeet.bounds.extents.y;
    }
    
    public void OnButtonPress()
    {
        if(isGrounded())
        {
            // Change the rigidbody velocity by the players jump height * 1
            playerBody.velocity = (Vector2.up * (playerStats.jumpHeight));

        }
  
    }

   bool isGrounded()
    {
        //jump.SetTrigger("Jump");
        return Physics2D.Raycast(playerPos.position, -Vector2.up, groundDist + touchDistance,platform);
        // Cast a ray downwards from the players center, if it hits any collider. within a distance of 0.1 then the player is grounded
    }


}
