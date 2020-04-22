using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private Rigidbody2D body;
    private FixedJoystick moveStick;
    private Collider2D playerCollide;
    private Transform tempRespawn;
    public Collider2D enemyBox;
    PlayerStats player;
    

    void Start()
    {
        player= GetComponent<PlayerStats>();
        body = GetComponent<Rigidbody2D>();
        moveStick = GameObject.FindWithTag("MoveStick").GetComponent<FixedJoystick>();
        tempRespawn = GameObject.FindWithTag("AutoRespawn").GetComponent<Transform>();
       
    }
    void Update()
    {
        Vector2 characterPos = transform.localScale;
        body.velocity = new Vector2(moveStick.Horizontal * player.speed, body.velocity.y);
      
        if(moveStick.Horizontal<0)
        {
            characterPos.x = 1;
        }
        if (moveStick.Horizontal > 0)
        {
            characterPos.x = -1;
        }

        transform.localScale = characterPos;


    }



}

