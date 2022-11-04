using Godot;
using System;

public partial class Minotaur : CharacterBody3D
{

	private AnimationPlayer _animationPlayer;
	private MobController _mobController;

	public override void _Ready()
	{
		_animationPlayer = GetNode<AnimationPlayer>("./AnimationPlayer");
		_mobController = GetNode<MobController>("./MobController");
		foreach (var animation in _animationPlayer.GetAnimationList())
		{
			GD.Print(animation);
		}

		GD.Print(_animationPlayer);
	}

	public override void _Process(double delta)
	{
		if (_mobController == null)
		{
			return;
		}
		if (_mobController.Target == null)
		{
			_animationPlayer.Play(AnimationNames.Idle);
			return;
		}
		var targetDirection = (_mobController.Target.Position - Position);
		targetDirection.y = 0;
		if (targetDirection.Length() < 0.0001)
		{
			return;
		}

        var moveDirection = targetDirection.Normalized();
		var speed = _mobController.IsAggressive ? 3f : 1f;
		if (_mobController.IsAggressive)
		{
            _animationPlayer.Play(AnimationNames.RunForward, customSpeed: 0.6f);
        }
        else
		{
            _animationPlayer.Play(AnimationNames.WalkForward, customSpeed: 0.2f);
        }
        Velocity = moveDirection * speed;
		LookAt(Position + moveDirection);

        if (MoveAndSlide())
		{
			var collision = GetLastSlideCollision();
			var collider = collision.GetCollider();
			if (collider is CharacterBody3D)
			{
				GD.Print(collider);
				var character = collider as CharacterBody3D;
			}
		}
	}
}
