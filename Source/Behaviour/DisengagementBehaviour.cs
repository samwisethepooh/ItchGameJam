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
        if (MobController.Intent == null)
        {
            return;
        }
        if (!(MobController.Intent is ChasePlayerIntent))
        {
            return;
        }

        var distanceToTarget = (MobController.Intent.Position - Mob.GlobalPosition).Length();
        if (distanceToTarget >= DisengagementRange)
        {
            MobController.ClearIntent();
        }
    }
}
