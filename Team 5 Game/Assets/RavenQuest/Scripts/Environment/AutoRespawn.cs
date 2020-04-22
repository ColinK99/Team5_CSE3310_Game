using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRespawn : MonoBehaviour
{
    private Transform player;
    public int minDistance = 10;
    private Rigidbody2D playerMove;
    private GameObject damage;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        playerMove = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        damage = GameObject.FindWithTag("Damage");
       
        
    }

    void FixedUpdate()
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2((player.position.x) - minDistance,player.position.y), Vector2.down, Mathf.Infinity);
        RaycastHit2D hitRight = Physics2D.Raycast(new Vector2((player.position.x) + minDistance, player.position.y), Vector2.down, Mathf.Infinity);


        if(hitLeft.collider.tag != damage.tag && hitRight.collider.tag != damage.tag)
        {
            
            transform.position = player.position;
        }

    }

    public void Respawn()
    {
        playerMove.velocity = Vector3.zero;
        player.position = transform.position;
    }
}
