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
