using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public partial class WaypointPathBehaviour : Behaviour
{
    private static int PriorityLevel = 1;
    private List<Node> _waypoints { get; set; } = new List<Node>();
    [Export] public Node WaypointA { get; set; }
    [Export] public Node WaypointB { get; set; }

    private int _currentTarget = 0;

    public override void _Ready()
	{
		base._Ready();

        if (WaypointA != null)
        {
            _waypoints.Add(WaypointA);
        }
        if (WaypointB != null)
        {
            _waypoints.Add(WaypointB);
        }
	}

	public override void _Process(double delta)
	{
        if (MobController.PriorityLevel > PriorityLevel)
        {
            return;
        }

        if (MobController.Target == null)
        {
            _currentTarget = (_currentTarget + 1) % _waypoints.Count;
            var target = _waypoints[_currentTarget];
            MobController.Target = new TargetLocation((target as Node3D).GlobalPosition);
            MobController.PriorityLevel = 1;
        }
        else
        {
            var distanceToTarget = (MobController.Target.Position - Mob.Position).Length();
            if (distanceToTarget < 1f)
            {
                MobController.Target = null;
                MobController.PriorityLevel = 0;
            }
        }

    }
}
