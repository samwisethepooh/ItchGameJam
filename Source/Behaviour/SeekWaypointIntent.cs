using Godot;

public class SeekWaypointIntent : IIntent
{
    public Vector3 Position { get; }

	public int Priority => 1;

	public SeekWaypointIntent(Vector3 position)
	{
		Position = position;
	}
}
