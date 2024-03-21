using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitState : BaseState
{
    private StateMachine _stateMachine;

    public Transform target;

    public override void OnEnter(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        target = _stateMachine.targetToPursuit;
    }

    public override void OnExit()
    {
        // Ne fais rien
    }

    public override void Update()
    {
        _stateMachine.main.movement.direction = (target.position - _stateMachine.transform.position).normalized  ;
       // checkForTransition();

    }
}
