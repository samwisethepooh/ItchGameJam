using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal static class GenerationHelper
{
    public static void GenerateWall(this IGeneratorOutput generatorOutput, Vector2i startXZ, Vector2i endXZ, int height, BlockType blockType, int everyNBlocks = 1)
    {
        for (int x = startXZ.x; x <= endXZ.x; x++)
        {
            for (int z = startXZ.y; z <= endXZ.y; z++)
            {
                if ((x+z) % everyNBlocks == 0)
                {
                    continue;
                }
                for (int y = 0; y < height; y++)
                {
                    generatorOutput.SetBlock(x, y, z, blockType);
                }
            }
        }
    }

    public static void GenerateWallSquare(this IGeneratorOutput generatorOutput, Vector2i startXZ, Vector2i endXZ, int height, BlockType blockType, int everyNBlocks = 1)
    {
        generatorOutput.GenerateWall(new Vector2i(startXZ.x, startXZ.y), new Vector2i(endXZ.x, startXZ.y), height, blockType, everyNBlocks);
        generatorOutput.GenerateWall(new Vector2i(startXZ.x, startXZ.y), new Vector2i(startXZ.x, endXZ.y), height, blockType, everyNBlocks);
        generatorOutput.GenerateWall(new Vector2i(endXZ.x, startXZ.y), new Vector2i(endXZ.x, endXZ.y), height, blockType, everyNBlocks);
        generatorOutput.GenerateWall(new Vector2i(startXZ.x, endXZ.y), new Vector2i(endXZ.x, endXZ.y), height, blockType, everyNBlocks);
    }
}
