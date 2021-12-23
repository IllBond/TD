using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenState : State
{
    public FallenState(EnemyCharacter character, StateMachine stateMachine) : base(character, stateMachine)
    { }

    public override void Enter()
    {
        character.animator.SetBool("fallen", true);
    }

    public override void HandleInput()
    { }

    public override void LogicUpdate()
    { }

    public override void PhysicsUpdate()
    { }

    public override void Exit()
    {
        character.animator.SetBool("fallen", false);
    }
}
