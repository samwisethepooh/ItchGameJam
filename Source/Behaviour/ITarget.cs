using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IIntent
{
    public Vector3 Position { get; }
    public int Priority { get; }
}
