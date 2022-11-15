using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class MobController : Node
{
    public ITarget Target { get; set; }
    public int PriorityLevel { get; set; } = 0;
    public bool IsAggressive { get; set; } = false;

    public override void _Ready()
    {
    }

    public override void _Process(double delta)
    {
    }
}
