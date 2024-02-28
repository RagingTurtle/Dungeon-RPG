using Godot;
using System;

public partial class Lightning : Ability
{
    public override void _Ready()
    {
        animationPlayerNode.AnimationFinished += (animationName) => QueueFree();
    }
}
