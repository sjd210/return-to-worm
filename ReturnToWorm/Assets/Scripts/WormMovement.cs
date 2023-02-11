using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormMovement : MonoBehaviour
{

    public float max_speed = 3f;
    public float max_acceleration = 1f;

    //dv = a * Time.FixedDeltaTime
    //drag = 1 - a * Time.FixedDeltaTime / v_max

    public float rotationSpeed = 200f;
    float velX = 0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        current_direction = new Vector2(1,0);
    }

    void Update()
    {
        velX = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        Store_Direction();
        Rotation_Scheme();
        Forward_Impulse();
        With_Boost();
        With_Drag();
    }
    public void Rotation_Scheme()
    {
        if(velX != 0) rb.velocity = Quaternion.AngleAxis(-velX * rotationSpeed * Time.fixedDeltaTime, Vector3.forward) * rb.velocity;
    }

    public void Forward_Impulse()
    {
        rb.velocity += current_direction * (max_acceleration * Time.fixedDeltaTime);
    }

    Vector2 current_direction;
    static Vector2 zero = new Vector2(0,0);
    public void Store_Direction()
    {
        if(rb.velocity != zero) current_direction = rb.velocity.normalized;
    }

    private float cooldown;
    private float boost;
    public float boost_speed = 20f;
    public float boost_length = 0.5f;
    public float cooldown_length = 3f;
    private Vector3 boost_direction;
    public void With_Boost()
    {

        if(cooldown >= 0) cooldown -= Time.fixedDeltaTime;
        if(boost >= 0) boost -= Time.fixedDeltaTime;
        
        if(Input.GetKey(KeyCode.Space) && cooldown <= 0){
            cooldown += cooldown_length;
            boost += boost_length;
            boost_direction = current_direction;
        }

        if(boost >= 0) rb.AddForce(boost_speed * boost_direction * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }

    public void With_Drag()
    {
        rb.velocity *= 1 - (max_acceleration * Time.fixedDeltaTime / max_speed);
    }

    
}
