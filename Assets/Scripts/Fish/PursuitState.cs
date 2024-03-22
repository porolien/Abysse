using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitState : BaseState
{
    private StateMachine _stateMachine;

    public Transform target;

    private bool targetIsAPlayer;

    public override void OnEnter(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        target = _stateMachine.targetToPursuit;
        if (target.GetComponent<PlayerMain>() != null )
        {
            targetIsAPlayer = true;
        }
        else
        {
            targetIsAPlayer = false;
        }
    }

    public override void OnExit()
    {
        // Ne fais rien
    }

    public override void Update()
    {
        _stateMachine.main.movement.direction = (target.position - _stateMachine.transform.position).normalized;
        
        if (!targetIsAPlayer && _stateMachine.main.afraidByLight) 
        {
            _stateMachine.main.movement.direction *= -1;
        }
       // checkForTransition();

    }
}
