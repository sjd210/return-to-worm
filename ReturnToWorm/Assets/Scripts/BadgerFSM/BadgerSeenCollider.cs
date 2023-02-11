using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BadgerFSM
{
    public class BadgerSeenCollider : MonoBehaviour
    {
        public BadgerFSM badgerFSM;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Worm"))
            {
                badgerFSM.OnWormSeen(other);
            }

        }
    }
}
