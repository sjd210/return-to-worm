using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head_Swarmite : Swarmite
{
    public float speed = 3f;
    //dv = a * Time.FixedDeltaTime
    //drag = 1 - a * Time.FixedDeltaTime / v_max

    public float rotationSpeed = 200f;
    float velX = 0f;


    // Update is called once per frame

    private void Update()
    {
        velX = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime, Space.Self);
        transform.Rotate(Vector3.forward * -velX * rotationSpeed * Time.fixedDeltaTime);
    }

}
