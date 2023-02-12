using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BadgerFSM
{
    public class BadgerFSM : WormStateMachine
    {
        public GameObject blood;
        public Rigidbody2D rb;

        public Animator animator;

        public SwarmMovement swarm;

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

        public AudioSource blood_noise;
        public AudioClip _blood_noise;

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

        public void MakeBlood()
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            swarm.AddWorm(3, transform.position);

            blood_noise = GetComponent<AudioSource>();
            blood_noise.PlayOneShot(_blood_noise, 0.7F);
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