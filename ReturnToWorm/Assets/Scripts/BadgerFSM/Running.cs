using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BadgerFSM
{
    public class Running : BaseState
    {
        private BadgerFSM stateMachine;

        public Running(BadgerFSM stateMachine) : base("Running", stateMachine) {
            this.stateMachine = stateMachine;
        }

        public override void UpdatePhysics()
        {
            base.UpdateLogic();
            Vector2 dir;
            if (this.stateMachine.transform.position.x - this.stateMachine.worm.transform.position.x > 0)
            {
                dir = Vector2.right;
            }
            else
            {
                dir = Vector2.left;
            }

            stateMachine.rb.AddForce(dir);
        }
    }
}