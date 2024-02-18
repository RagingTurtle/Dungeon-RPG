using Godot;
using System;

public partial class EnemyPatrolState : EnemyState
{
    private int pointIndex = 0;
    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);

        pointIndex = 1;

        destination = GetPointsGlobalPosition(pointIndex);    
        characterNode.AgentNode.TargetPosition = destination;

        characterNode.AgentNode.NavigationFinished += HandleNavigationFinished;
    }

    public override void _PhysicsProcess(double delta)
    {
        Move();
    }

    private void HandleNavigationFinished()
    {
        pointIndex = Mathf.PosMod(pointIndex + 1, characterNode.PathNode.Curve.PointCount);

        destination = GetPointsGlobalPosition(pointIndex);
        characterNode.AgentNode.TargetPosition = destination;
    }
}
