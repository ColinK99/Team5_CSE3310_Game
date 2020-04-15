using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCheck : MonoBehaviour
{
    public float gravityMult = 2.5f;
   

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(rb.velocity.y<0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (gravityMult - 1) * Time.deltaTime;
        }
    }
}
