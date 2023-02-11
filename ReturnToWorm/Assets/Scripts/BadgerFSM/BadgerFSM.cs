using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BadgerFSM
{
    public class BadgerFSM : StateMachine
    {
        public Rigidbody2D rb;

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

        protected override BaseState GetInitialState()
        {
            
            return idleState;
        }



        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Worm"))
            {
                worm = other.gameObject;
                ChangeState(deadState);
            }
           
        }

        public void OnWormSeen(Collider2D other)
        {
            worm = other.gameObject;
            ChangeState(runningState);
        }
    }
}