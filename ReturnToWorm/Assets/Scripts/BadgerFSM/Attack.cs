using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BadgerFSM
{
    public class Attack : WormState
    {
        BadgerFSM stateMachine;
        public Attack(BadgerFSM stateMachine) : base("Attack", stateMachine) { }

        public override void Enter()
        {
            base.Enter();
            stateMachine.animator.SetTrigger("Dead");

        }

        public override void OnWormTouched(Collider2D collider2D)
        {
            base.OnWormTouched(collider2D);
            stateMachine.ChangeState(stateMachine.deadState);
        }
    }
}