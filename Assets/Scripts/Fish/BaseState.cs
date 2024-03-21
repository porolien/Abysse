using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState 
{
    public abstract void OnEnter(StateMachine stateMachine);

    public abstract void OnExit();

    public abstract void Update();
}
    

