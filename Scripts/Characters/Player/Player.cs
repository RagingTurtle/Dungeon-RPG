using Godot;
using System;

public partial class Player : CharacterBody3D
{
    public override void _PhysicsProcess(double delta)
    {
        //GD.Print("player physics process");
    }

    public override void _Input(InputEvent @event)
    {
        GD.Print(@event);
    }
}
