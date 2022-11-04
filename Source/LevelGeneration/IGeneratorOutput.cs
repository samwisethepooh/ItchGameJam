using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IGeneratorOutput
{
    void SetBlock(int x, int y, int z, BlockType blockType);
}
