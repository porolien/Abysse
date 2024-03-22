using UnityEngine;

public class PatrolState : BaseState
{
    private StateMachine _stateMachine;

    private PatrolPath _path;

    public override void OnEnter(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;

        _path = _stateMachine.main.patrol;
        if (_path.patrolPoints.Count != 0)
        {
            InitNewPathPoint();
        }

        _stateMachine.main.detection.seeALight += GetDetect;
    }

    public override void OnExit()
    {
        // Ne fais rien
    }

    public override void Update()
    {
        if (_path.patrolPoints.Count != 0)
        {
            Vector3 _direction = _path.actualPoint.position - _stateMachine.transform.position;

            if (Mathf.Abs(_direction.x) + Mathf.Abs(_direction.y) < 1)
            {
                FollowThePath();
            }
        }
    }

    private void CheckForTransition(Transform pos)
    {
        _stateMachine.targetToPursuit = pos;
        _stateMachine.Transition(_stateMachine.pursuitState);
    }

    private void GetDetect(Transform pos)
    {
        CheckForTransition(pos);
    }

    private void FollowThePath()
    {
        if (_path.actualPointIndexer < _path.patrolPoints.Count - 1)
        {
            _path.actualPointIndexer++;
        }
        else
        {
            _path.actualPointIndexer = 0;
        }

        InitNewPathPoint();
    }

    private void InitNewPathPoint()
    {
        _path.actualPoint = _path.patrolPoints[_path.actualPointIndexer];
        _stateMachine.main.movement.direction = (_path.actualPoint.position - _stateMachine.transform.position).normalized;
        _stateMachine.main.movement.body.LookAt(_path.actualPoint);
    }
}