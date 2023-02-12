using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormMovement : Swarmite
{

   
    public float speed = 1f;
    //dv = a * Time.FixedDeltaTime
    //drag = 1 - a * Time.FixedDeltaTime / v_max

    public float rotationSpeed = 200f;
    float velX = 0f;
    //public Rigidbody2D rb;

    /*void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //current_direction = new Vector2(1,0);
    }
    */
    void Update()
    {
        velX = Input.GetAxisRaw("Horizontal");
    }

   public void FixedUpdate()
    {
        //transform.Translate(Vector2.up * speed * Time.fixedDeltaTime, Space.Self);
        //transform.Rotate(Vector3.forward * -velX * rotationSpeed * Time.fixedDeltaTime);
        rb.velocity *= 0.95f;
    }
}
