using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BadgerFSM
{
    public class Idle : WormState
    {
        public BadgerFSM stateMachine;
        public Idle(BadgerFSM stateMachine) : base("Idle", stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public override void OnWormTouched(Collider2D collider2D)
        {
            base.OnWormTouched(collider2D);
            stateMachine.ChangeState(stateMachine.deadState);
        }

        public override void OnWormSeen(Collider2D collider2D)
        {
            base.OnWormTouched(collider2D);
            stateMachine.ChangeState(stateMachine.runningState);
        }
    }
}