using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BadgerFSM
{
    public class Dead : BaseState
    {
        private BadgerFSM stateMachine;

        public Dead(BadgerFSM stateMachine) : base("Dead", stateMachine)
        {
            this.stateMachine = stateMachine;
        }
        public override void Enter()
        {
            base.Enter();
            stateMachine.rb.velocity = new Vector2(0, 0);

        }
        public override bool Exit()
        {
            base.Exit();
            return false;
        }

    }
}