using Godot;
using System;

public partial class EnemyReturnState : EnemyState
{
    private Vector3 destination;

    public override void _Ready()
    {
        base._Ready();

        Vector3 localPos = characterNode.PathNode.Curve.GetPointPosition(0);
        Vector3 globalPos = characterNode.PathNode.GlobalPosition;
        destination = localPos + globalPos;
 
        characterNode.GlobalPosition = destination;
    }

    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);
    }
}
