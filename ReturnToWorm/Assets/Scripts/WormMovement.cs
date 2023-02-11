using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormMovement : MonoBehaviour
{

    public float max_speed = 3f;
    public float max_acceleration = 1f;
    public float speed = 1f;
    //dv = a * Time.FixedDeltaTime
    //drag = 1 - a * Time.FixedDeltaTime / v_max

    public float rotationSpeed = 200f;
    float velX = 0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //current_direction = new Vector2(1,0);
    }

    void Update()
    {
        velX = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime, Space.Self);
        transform.Rotate(Vector3.forward * -velX * rotationSpeed * Time.fixedDeltaTime);
    }
}
