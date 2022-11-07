using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IActivatable
{
    void Activate(bool isActive, Node3D source, CharacterBody3D invoker);
}
