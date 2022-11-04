using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class DisengagementBehaviour : Behaviour
{
    [Export] public float DisengagementRange { get; set; } = 30f;

    public override void _Process(double delta)
    {
        if (MobController.Target == null)
        {
            return;
        }

        var distanceToTarget = (MobController.Target.Position - Mob.Position).Length();
        GD.Print(distanceToTarget);
        if (distanceToTarget >= DisengagementRange)
        {
            MobController.Target = null;
        }
    }
}
