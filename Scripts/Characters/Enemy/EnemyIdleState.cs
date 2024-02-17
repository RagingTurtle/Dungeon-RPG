using Godot;
using System;

public partial class EnemyIdleState : EnemyState
{
    public override void _PhysicsProcess(double delta)
    {
        if (characterNode.direction != Vector2.Zero)
        {
            characterNode.StateMachineNode.SwitchState<EnemyMoveState>();
        }
    }

    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_IDLE);
    }
}
