using Godot;
using System;

public partial class Bomb : Ability
{
    public override void _Ready()
    {
        animationPlayerNode.AnimationFinished += HandleExpandAnimationFinished;
    }

    private void HandleExpandAnimationFinished(StringName animationName)
    {
        if (animationName == GameConstants.ANIM_EXPAND)
        {
            animationPlayerNode.Play(GameConstants.ANIM_EXPLOSION);
        }
        if (animationName == GameConstants.ANIM_EXPLOSION)
        {
            QueueFree();
        }
    }

}
