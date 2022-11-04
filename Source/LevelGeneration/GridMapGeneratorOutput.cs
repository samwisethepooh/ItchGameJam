using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class GridMapGeneratorOutput : IGeneratorOutput
{
	private GridMap _gridMap;

	public GridMapGeneratorOutput(GridMap gridMap)
	{
		_gridMap = gridMap;
	}

	public void SetBlock(int x, int y, int z, BlockType blockType)
	{
		_gridMap.SetCellItem(new Vector3i(x, y, z), (int)blockType, 0);
		GD.Print($"{x} {y} {z} {blockType}");
	}
}
