using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    public StateMachine stateMachine;

    public IdleState idleState;
    public MovingState movingState;
    public FallenState fallenState;
    public VictoryState victoryState;

    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        stateMachine = new StateMachine();

        idleState = new IdleState(this, stateMachine);
        movingState = new MovingState(this, stateMachine);
        fallenState = new FallenState(this, stateMachine);
        victoryState = new VictoryState(this, stateMachine);

        stateMachine.Initialize(idleState);
    }

    private void FixedUpdate()
    {
        stateMachine.CurrentState.PhysicsUpdate();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            stateMachine.ChangeState(idleState);
            Debug.Log("Стоит");
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            stateMachine.ChangeState(movingState);
            Debug.Log("Идет");
        }


        if (Input.GetKeyUp(KeyCode.E))
        {
            stateMachine.ChangeState(fallenState);
            Debug.Log("Падает");
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            stateMachine.ChangeState(victoryState);
            Debug.Log("Победа");
        }

        stateMachine.CurrentState.HandleInput();
        stateMachine.CurrentState.LogicUpdate();
    }

}
