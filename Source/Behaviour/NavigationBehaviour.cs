using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public partial class NavigationBehaviour : Behaviour
{

    private AnimationPlayer _animationPlayer;

    public override void _Ready()
    {
        base._Ready();
        _animationPlayer = Mob.GetNode<AnimationPlayer>("./AnimationPlayer");
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
        var targetDirection = (MobController.Target.Position - Mob.Position);
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
            _animationPlayer.Play(AnimationNames.WalkForward, customSpeed: 0.2f);
        }
        Mob.Velocity = moveDirection * speed;
        Mob.LookAt(Mob.Position + moveDirection);
    }
}
