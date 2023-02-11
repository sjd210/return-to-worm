using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormGrow : MonoBehaviour
{
    public WormTail wormTail;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            Destroy(other.gameObject, 0.02f);
            wormTail.AddTail();
        }
    }
}
