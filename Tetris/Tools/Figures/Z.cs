using System;
using System.Drawing;

namespace Tetris.Tools.Figures
{
    class Z:Figure
    {
        public Z(int x,int y,Color color)
        {
            Cells.Add(new Cell(x, y, -1, 1, color));
            Cells.Add(new Cell(x, y + 1, 0, 1, color));
            Cells.Add(new Cell(x + 1, y + 1, 0, 0, color));
            Cells.Add(new Cell(x + 1, y + 2, 1, 0, color));
        }
    }
}
