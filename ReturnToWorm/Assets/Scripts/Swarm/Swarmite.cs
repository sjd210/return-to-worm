using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swarmite : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity *= 0.95f;
    }

}
