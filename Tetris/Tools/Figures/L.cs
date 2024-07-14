using System;
using System.Drawing;

namespace Tetris.Tools.Figures
{
    class L: Figure
    {
        public L(int x,int y,Color color)
        {
            Cells.Add(new Cell(x, y, 0, 1, color));
            Cells.Add(new Cell(x + 1, y, 0, 0, color));
            Cells.Add(new Cell(x + 2, y, 0, -1, color));
            Cells.Add(new Cell(x + 2, y + 1, 1, -1, color));
        }
    }
}
