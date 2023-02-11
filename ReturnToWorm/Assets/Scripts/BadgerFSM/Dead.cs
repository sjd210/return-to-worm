using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BadgerFSM
{
    public class Dead : WormState
    {
        private BadgerFSM stateMachine;
        private float start_death;
        private bool blood_spawned = false;
        public Dead(BadgerFSM stateMachine) : base("Dead", stateMachine)
        {
            this.stateMachine = stateMachine;
        }
        public override void Enter()
        {
            base.Enter();
            stateMachine.rb.velocity = Vector2.zero;
            stateMachine.rb.angularVelocity = 0;
            stateMachine.animator.SetTrigger("Dead");
            start_death = Time.time;
        }

        public override void UpdatePhysics()
        {
            base.UpdatePhysics();
            stateMachine.rb.velocity = Vector2.zero;
            stateMachine.rb.angularVelocity = 0;
            if (!blood_spawned && Time.time - start_death > 2)
            {
                blood_spawned = true;
                stateMachine.MakeBlood();
            }

        }
        public override bool Exit()
        {
            base.Exit();
            return false;
        }

    }
}