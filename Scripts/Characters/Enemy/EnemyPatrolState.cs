using Godot;
using System;

public partial class EnemyPatrolState : EnemyState
{
    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);

        destination = GetPointsGlobalPosition(1);    
        characterNode.AgentNode.TargetPosition = destination;
    }

    public override void _PhysicsProcess(double delta)
    {
        Move();
    }
}
