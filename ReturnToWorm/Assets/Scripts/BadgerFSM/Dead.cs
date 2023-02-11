using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BadgerFSM
{
    public class Dead : WormState
    {
        private BadgerFSM stateMachine;

        public Dead(BadgerFSM stateMachine) : base("Dead", stateMachine)
        {
            this.stateMachine = stateMachine;
        }
        public override void Enter()
        {
            base.Enter();
            stateMachine.rb.velocity =  Vector2.zero;
            stateMachine.rb.angularVelocity = 0;
            stateMachine.animator.SetTrigger("Dead");

        }

        public override void UpdatePhysics()
        {
            base.UpdatePhysics();
            stateMachine.rb.velocity = Vector2.zero;
            stateMachine.rb.angularVelocity = 0;
        }
        public override bool Exit()
        {
            base.Exit();
            return false;
        }

    }
}