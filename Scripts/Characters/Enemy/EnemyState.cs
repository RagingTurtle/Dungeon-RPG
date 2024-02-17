using Godot;

public abstract partial class EnemyState : Node
{    
    protected Enemy characterNode;
    public override void _Ready()
    {
        characterNode = GetOwner<Enemy>();
        SetPhysicsProcess(false);
        SetProcessInput(false);
    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        if (what == GameConstants.NOTIFICATION_ENTER_STATE)
        {
            EnterState();
            SetPhysicsProcess(true);
            SetProcessInput(true);
        }
        else if (what == GameConstants.NOTIFICATION_EXIT_STATE)
        {
            SetPhysicsProcess(false);
            SetProcessInput(false);
        }
    }

    protected virtual void EnterState() { }
}