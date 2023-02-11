using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BadgerFSM
{
    public class BadgerFSM : WormStateMachine
    {
        public Rigidbody2D rb;

        public Animator animator;

        [HideInInspector]
        public GameObject worm;

        [HideInInspector]
        public Idle idleState;
        [HideInInspector]
        public Running runningState;
        [HideInInspector]
        public Frozen frozenState;
        [HideInInspector]
        public Attack attackState;
        [HideInInspector]
        public Dead deadState;

        private void Awake()
        {
            idleState = new Idle(this);
            runningState = new Running(this);
            frozenState = new Frozen(this);
            attackState = new Attack(this);
            deadState = new Dead(this);

        }

        protected override WormState GetInitialState()
        {
            
            return idleState;
        }



        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Worm"))
            {
                worm = other.gameObject;
                currentState.OnWormTouched(other);                
            }
           
        }

        public void OnWormSeen(Collider2D other)
        {
            worm = other.gameObject;
            currentState.OnWormSeen(other);
        }
    }
}