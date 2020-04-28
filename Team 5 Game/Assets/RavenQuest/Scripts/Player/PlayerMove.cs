using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private Rigidbody2D body;
    private FixedJoystick moveStick;
    PlayerStats player;
    private Animator anim;
    private Vector2 startPoint;
    

    void Start()
    {
        player= GetComponent<PlayerStats>();
        body = GetComponent<Rigidbody2D>();
        moveStick = GameObject.FindWithTag("MoveStick").GetComponent<FixedJoystick>();
        anim = GetComponent<Animator>();
        startPoint = GetComponent<Transform>().position;
        
       
    }
    void Update()
    {
        Vector2 characterPos = transform.localScale;
        body.velocity = new Vector2(moveStick.Horizontal * player.speed, body.velocity.y);
        if (moveStick.Horizontal == 0)
        { 
            anim.SetBool("running", false);
        }
        else
        {
            anim.SetBool("running", true);
        }
      if (moveStick.Horizontal < 0)
      {
          characterPos.x = -1;
      }
      if (moveStick.Horizontal > 0)
      {
         characterPos.x = 1;
      }

        transform.localScale = characterPos;
        

    }



}

