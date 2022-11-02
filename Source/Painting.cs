using Godot;
using System;

public partial class Painting : Node
{
	[Export] public Texture2D Texture { get; set; }
	private MeshInstance3D _screen;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_screen = GetNode<MeshInstance3D>("./Screen");
		_screen.SetSurfaceOverrideMaterial(0, new StandardMaterial3D()
		{
			AlbedoTexture = Texture
		});
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
