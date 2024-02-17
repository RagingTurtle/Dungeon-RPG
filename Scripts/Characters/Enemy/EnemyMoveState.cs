using Godot;
using System;

public partial class EnemyMoveState : EnemyState
{
    [Export(PropertyHint.Range, "0, 10, 0.1")] private float speed = 5;
    public override void _PhysicsProcess(double delta)
    {
        if (characterNode.direction == Vector2.Zero)
        {
            characterNode.StateMachineNode.SwitchState<EnemyIdleState>();
            return;
        }

        characterNode.Velocity = new(characterNode.direction.X, 0, characterNode.direction.Y);
        characterNode.Velocity *= speed;

        characterNode.MoveAndSlide();

        characterNode.Flip();
    }

    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);
    }
}
