using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BadgerFSM
{
    public class Running : WormState
    {
        private BadgerFSM stateMachine;

        public Running(BadgerFSM stateMachine) : base("Running", stateMachine) {
            this.stateMachine = stateMachine;
        }

        public override void Enter()
        {
            base.Enter();
            stateMachine.animator.SetTrigger("Running");

        }
        public override void UpdatePhysics()
        {
            base.UpdateLogic();
            Vector2 dir;
            if (this.stateMachine.transform.position.x - this.stateMachine.worm.transform.position.x > 0)
            {
                dir = Vector2.right;
                Vector3 theScale = stateMachine.transform.localScale;
                theScale.x = 1;
                stateMachine.transform.localScale = theScale;
            }
            else
            {
                dir = Vector2.left;
                Vector3 theScale = stateMachine.transform.localScale;
                theScale.x = -1;
                stateMachine.transform.localScale = theScale;
            }

            stateMachine.rb.velocity = dir*2;
        }

        public override void OnWormTouched(Collider2D collider2D)
        {
            base.OnWormTouched(collider2D);
            stateMachine.ChangeState(stateMachine.deadState);
        }
    }
}