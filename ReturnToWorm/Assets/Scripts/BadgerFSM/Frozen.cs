using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BadgerFSM
{
    public class Frozen : BaseState
    {
        private BadgerFSM stateMachine;

        public Frozen(BadgerFSM stateMachine) : base("Frozen", stateMachine) {
            this.stateMachine = stateMachine;
        }

        public override void UpdatePhysics()
        {
            base.UpdatePhysics();
            stateMachine.rb.velocity = new Vector2(0,0);
        }

    }
}