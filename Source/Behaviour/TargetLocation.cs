using Godot;

public class TargetLocation : ITarget
{
    public Vector3 Position { get; }

	public TargetLocation(Vector3 position)
	{
		Position = position;
	}
}
