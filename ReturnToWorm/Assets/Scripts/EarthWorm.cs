using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthWorm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public float speed = 1f;
    public float life_time = 1f;
    void FixedUpdate()
    {
        if(life_time > 0f) life_time -= Time.fixedDeltaTime;
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime, Space.Self);
    }
}
