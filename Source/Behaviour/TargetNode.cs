using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TargetNode : ITarget
{
	private readonly Node3D _node;

	public Vector3 Position => _node.Position;

	public TargetNode(Node3D node)
	{
		_node = node;
	}
}
