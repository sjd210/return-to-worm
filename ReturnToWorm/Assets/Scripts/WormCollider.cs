using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormCollider : MonoBehaviour
{

    public GameObject tiles;

    private void Start()
    {
        string[] prohibitedCollisions = {"Enemy", "Wall", "Worm"};

        foreach (string tag in prohibitedCollisions)
        {
            GameObject[] items = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject item in items)
            {
                Physics2D.IgnoreCollision(item.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
        }
    }
}

