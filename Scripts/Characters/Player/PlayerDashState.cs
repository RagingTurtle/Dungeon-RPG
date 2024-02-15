using Godot;
using System;

public partial class PlayerDashState : Node
{
    private Player characterNode;
    [Export] private Timer dashTimerNode;

    public override void _Ready()
    {
        characterNode = GetOwner<Player>();
        dashTimerNode.Timeout += HandleDashTimeout;
    }

    private void HandleDashTimeout()
    {
        characterNode.stateMachineNode.SwitchState<PlayerIdleState>();    
    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        if (what == 5001)
        {
            characterNode.animationPlayerNode.Play(GameConstants.ANIM_DASH);
            dashTimerNode.Start();
        }
    }
}
