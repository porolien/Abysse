using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState currentState;
    public PursuitState pursuitState;
    public PatrolState patrolState;

    public FishMain main;

    public Transform targetToPursuit;

    public void Init(FishMain _main)
    {
        main = _main;
        main.stateMachine = this;
    }

    private void Start()
    {
        pursuitState = new PursuitState();
        patrolState = new PatrolState();
        Transition(patrolState);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
    }

    public void Transition(BaseState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }

        currentState = newState;
        currentState.OnEnter(this);
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class BossStateMachine : MonoBehaviour
{
    public BossMain bossMain;
    public BaseBossState currentState;
    public IdleState idleState;
    public WalkState walkState;
    public RightAttackState rightAttackState;
    public LeftAttackState leftAttackState;
    public BasicHealState basicHealState;
    public UpgradedHealState upgradedHealState;
    public TornadoState tornadoState;
    public DualWeaponsProjectionState dualWeaponsProjectionState;

    public GameObject playerMain;
    public float distanceMax;

    public void Init(BossMain main)
    {
        bossMain = main;
        main.bossStateMachine = this;
        playerMain = FindAnyObjectByType(typeof(PlayerMain)).GetComponent<PlayerMain>().gameObject;
    }

    // Start is called before the first frame update
    void Awake()
    {

        idleState = new IdleState();
        walkState = new WalkState();
        rightAttackState = new RightAttackState();
        leftAttackState = new LeftAttackState();
        basicHealState = new BasicHealState();
        upgradedHealState = new UpgradedHealState();
        tornadoState = new TornadoState();
        dualWeaponsProjectionState = new DualWeaponsProjectionState();
        Transition(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null) currentState.Update();
    }

    public void Transition(BaseBossState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = newState;
        currentState.OnEnter(this);
    }
}
*/