using Godot;
using System;

public partial class Stairs : Node3D
{
	[Export] public string NextLevelPath { get; set; }
	
	public override void _Ready()
	{
		GetNode<NextLevelArea>("./NextLevelArea").NextLevelPath = NextLevelPath;
    }
}
