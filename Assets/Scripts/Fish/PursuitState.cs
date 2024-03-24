using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitState : BaseState
{
    private StateMachine _stateMachine;

    public Transform target;

    private Vector3 _oldTargetPosition;

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
        if (target != null)
        {
            if (!targetIsAPlayer && target.position.y < LimitManager.instance.minLimit)
            {
                target = null;
                _stateMachine.targetToPursuit = null;
                _stateMachine.Transition(_stateMachine.patrolState);
            }
            else
            {
                _oldTargetPosition = target.position;
                _stateMachine.main.movement.direction = (target.position - _stateMachine.transform.position).normalized;

                if (!targetIsAPlayer && _stateMachine.main.afraidByLight)
                {
                    _stateMachine.main.movement.direction *= -1;
                }
            }
            
        }
        else
        {
            Vector3 _direction = _oldTargetPosition - _stateMachine.transform.position;

            if (Mathf.Abs(_direction.x) + Mathf.Abs(_direction.y) < 1)
            {
                _stateMachine.Transition(_stateMachine.patrolState);
            }
        }
        
       // checkForTransition();

    }
}
