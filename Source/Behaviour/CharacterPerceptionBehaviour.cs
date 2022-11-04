using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class CharacterPerceptionBehaviour : Behaviour
{
    [Export] public float ViewRange { get; set; } = 10f;

    public override void _Process(double delta)
    {
        if (MobController == null)
        {
            return;
        }

        var root = GetTree().Root.GetNode("Level");
        var players = root.GetChildren()
            .Where(x => ((string)x.Name).StartsWith("Player", StringComparison.InvariantCultureIgnoreCase))
            .Cast<Node3D>();
        foreach (var player in players)
        {
            if ((player.Position - Mob.Position).Length() < ViewRange) {
                MobController.Target = new TargetNode(player);
            }
        }
    }
}
