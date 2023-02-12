using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormCollider : MonoBehaviour
{

    public GameObject tiles;

    private void Start()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Physics2D.IgnoreCollision(enemy.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        GameObject[] b = GameObject.FindGameObjectsWithTag("Wall");
        foreach (GameObject bg in b)
        {
            Debug.Log(bg);
            Physics2D.IgnoreCollision(bg.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}

