using Godot;

public abstract partial class Ability : Node3D
{
        [Export] public int Damage { get; private set; } = 10;
        [Export] protected AnimationPlayer animationPlayerNode;
}