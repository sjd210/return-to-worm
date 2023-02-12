using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BadgerFSM
{
    public class BadgerSeenCollider : MonoBehaviour
    {
        public GameObject badgerFSM;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Worm"))
            {
                badgerFSM.GetComponent<BadgerFSM>().OnWormSeen(other);
            }

            Debug.Log("AAAAAA");
        }
    }
}
