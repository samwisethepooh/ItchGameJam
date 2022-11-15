using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public partial class NavigationBehaviour : Behaviour
{

	private AnimationPlayer _animationPlayer;
	private NavigationAgent3D _navigationAgent3D;

	public override void _Ready()
	{
		base._Ready();
		_animationPlayer = Mob.GetNode<AnimationPlayer>("./AnimationPlayer");
		_navigationAgent3D = Mob.GetNode<NavigationAgent3D>("./NavigationAgent3D");

        foreach (var animation in _animationPlayer.GetAnimationList())
		{
			GD.Print(animation);
		}
	}

	public override void _Process(double delta)
	{
		if (MobController.Target == null)
		{
			_animationPlayer.Play(AnimationNames.Idle);
			return;
		}

		_navigationAgent3D.SetTargetLocation(MobController.Target.Position);
		var nextLocation = _navigationAgent3D.GetNextLocation();

		var targetDirection = (nextLocation - Mob.Position);
		targetDirection.y = 0;
		if (targetDirection.Length() < 0.0001)
		{
			return;
		}

		var moveDirection = targetDirection.Normalized();
		var speed = MobController.IsAggressive ? 4f : 2f;
		if (MobController.IsAggressive)
		{
			_animationPlayer.Play(AnimationNames.RunForward, customSpeed: 0.6f);
		}
		else
		{
			_animationPlayer.Play(AnimationNames.WalkForward, customSpeed: 0.3f);
		}
		Mob.Velocity = moveDirection * speed;
		Mob.LookAt(Mob.Position + moveDirection);
	}
}
