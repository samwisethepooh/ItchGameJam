using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class GridMapBootstrapper : Node
{
    private GridMap _gridMap;
    private IGenerator _generator = null;

    [Export]
    public Node Generator
    {
        get => _generator as Node;
        set => _generator = value as IGenerator;
    }

    [Export]
    public Node GridMap
    {
        get => _gridMap as Node;
        set => _gridMap = value as GridMap;
    }

    public override void _Ready()
    {
        GD.Print("Ready");
        GD.Print(_generator);
        GD.Print(_gridMap);
        if (_generator != null
            && _gridMap != null)
        {
            (Generator as IGenerator)?.Generate(new GridMapGeneratorOutput(_gridMap));
        }
        else
        {
            GD.PrintErr("Generator and gridmap not correctly configured!");
        }
    }
}
