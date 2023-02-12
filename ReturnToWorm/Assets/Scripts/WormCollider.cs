using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormCollider : MonoBehaviour
{

    public GameObject box;

    private void Start()
    {
        Physics2D.IgnoreCollision(box.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            Debug.Log("AAAA");
            Physics2D.IgnoreCollision(other, GetComponent<Collider2D>());
        }

    } */

    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            Debug.Log("AAAA");
           
        }
    } */
}

