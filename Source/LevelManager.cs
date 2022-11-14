using Godot;
using System;

public partial class LevelManager : Node
{
	public override void _Ready()
	{
	}

	public void SetActiveScene(string scene)
	{
		var root = GetTree().Root;
		if (root.HasNode("Level"))
		{
			var existingLevel = GetTree().Root.GetNode<Node>("Level");
			GetTree().Root.RemoveChild(existingLevel);
		}
		var sceneResource = ResourceLoader.Load<PackedScene>(scene);
		SetActiveScene(sceneResource);
	}

	public void SetActiveScene(PackedScene scene)
	{
        var newLevel = scene.Instantiate();
        newLevel.Name = "Level";
        GetTree().Root.AddChild(newLevel);
    }
}
