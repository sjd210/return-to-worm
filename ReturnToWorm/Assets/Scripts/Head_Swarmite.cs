using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head_Swarmite : Swarmite
{
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    public float speed = 2f;
    void FixedUpdate()
    {
        rb.velocity *= 0.90f;

        if (Input.GetKey(KeyCode.A))
            rb.AddForce(Vector3.left*speed, ForceMode2D.Impulse);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(Vector3.right*speed, ForceMode2D.Impulse);
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(Vector3.up*speed, ForceMode2D.Impulse);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(Vector3.down*speed, ForceMode2D.Impulse);
    }

}
