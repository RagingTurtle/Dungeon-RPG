using Godot;
using System;
using System.Linq;
using System.Threading.Channels;

public partial class EnemyAttackState : EnemyState
{
    private Vector3 targetPosition;
    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_ATTACK);

        Node3D target = characterNode.AttackAreaNode.GetOverlappingBodies().First();

        targetPosition = target.GlobalPosition;
    }

    private void PerformHit()
    {
        characterNode.ToggleHitbox(false);
        characterNode.HitboxNode.GlobalPosition = targetPosition;
    }
}
