using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class WormState
{
    public string name;
    protected WormStateMachine stateMachine;
    
    public WormState(String name, WormStateMachine stateMachine)
    {
        this.name = name;
        this.stateMachine = stateMachine;
    }
    public virtual void Enter() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
    public virtual bool Exit() { return true; }

    public virtual void OnWormSeen(Collider2D collider2D)
    {
    }

    public virtual void OnWormTouched(Collider2D collider2D)
    {
    }
}
