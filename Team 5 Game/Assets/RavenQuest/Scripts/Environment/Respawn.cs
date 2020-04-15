using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Transform player;
    private Vector3 start;
    // Start is called before the first frame update
    void Start()
    {
        // Set the point where player starts as the spawnpoint
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        start = new Vector3(transform.position.x,transform.position.y,0);
    }

    public void Spawn()
    {
        // Changep player position to start
        player.position = start; 
    }
}
