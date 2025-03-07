using Godot;
using System;

public partial class Lever : Node3D, IActivatable
{
	private AnimationPlayer _animationPlayer;
	private CharacterBody3D _lastInvoker;
	private bool _active = false;

	[Export] public Node Target { get; set; }
	[Export] public bool Active { get => _active; set => UpdateActive(value); }

	public override void _Ready()
	{
		_animationPlayer = GetNode<AnimationPlayer>("./AnimationPlayer");
		PlayAnimation();
    }

	public void UpdateActive(bool active)
	{
		_active = active;
		PlayAnimation();
        if (Target != null)
        {
            var activatable = Target as IActivatable;
            activatable.Activate(Active, this, _lastInvoker);
        }
    }

	private void PlayAnimation()
	{
        if (Active)
        {
            _animationPlayer.Play("PushDown");
        }
        else
        {
            _animationPlayer.Play("PullUp");
        }
    }

	public void Use(CharacterBody3D invoker)
	{
		GD.Print("used");
		GD.Print(invoker.GetType().Name);
		_lastInvoker = invoker;
        Active = !Active;
	}

	public void Activate(bool isActive, Node3D source, CharacterBody3D invoker)
	{
		Active = !Active;
	}
}
