using Godot;
using System;
using System.Xml.XPath;
using System.Linq;

public abstract partial class Character : CharacterBody3D
{
    [Export] private StatResource[] stats;

    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer AnimationPlayerNode {get; private set;}
    [Export] public Sprite3D Sprite3DNode {get; private set;}
    [Export] public StateMachine StateMachineNode {get; private set;}
    [Export] public Area3D HurtboxNode {get; private set;}
    [Export] public Area3D HitboxNode {get; private set;}
    [Export] public CollisionShape3D HitboxShapeNode {get; private set;}
    [Export] public Timer ShaderTimerNode {get; private set;}

    [ExportGroup("AI Nodes")]
    [Export] public Path3D PathNode {get; private set;}
    [Export] public NavigationAgent3D AgentNode {get; private set;}
    [Export] public Area3D ChaseAreaNode {get; private set;}
    [Export] public Area3D AttackAreaNode {get; private set;}

    public Vector2 direction = new();
    private ShaderMaterial shader;

    public override void _Ready()
    {
        shader = (ShaderMaterial)Sprite3DNode.MaterialOverlay;

        HurtboxNode.AreaEntered += HandleHurtboxEntered;
        Sprite3DNode.TextureChanged += HandleTextureChanged;
        ShaderTimerNode.Timeout += HandleShaderTimeout;
    }

    private void HandleShaderTimeout()
    {
        shader.SetShaderParameter("active", false);
    }

    private void HandleTextureChanged()
    {
        shader.SetShaderParameter("tex", Sprite3DNode.Texture);
    }

    private void HandleHurtboxEntered(Area3D area)
    {
        if (area is not IHitbox hitbox) { return; }
        
        StatResource health = GetStatResource(Stat.Health);

        float damage = hitbox.GetDamage();

        health.StatValue -= damage;

        GD.Print(health.StatValue);

        shader.SetShaderParameter("active", true);

        ShaderTimerNode.Start();
    }

    public StatResource GetStatResource(Stat stat)
    {
        return stats.Where((element) => element.StatType == stat).FirstOrDefault();
/*      
        StatResource result = null;

        foreach (StatResource element in stats)
        {
            if (element.StatType == stat)
            {
                result = element;
            }
        }
         
        return result;
 */    
    }

    public void Flip()
    {
        bool isNotMovingHorizontally = Velocity.X == 0;

        if (isNotMovingHorizontally) { return;}

        bool isMovingLeft = Velocity.X < 0;
        Sprite3DNode.FlipH = isMovingLeft;
    }

    public void ToggleHitbox(bool flag)
    {
        HitboxShapeNode.Disabled = flag;
    }
}
