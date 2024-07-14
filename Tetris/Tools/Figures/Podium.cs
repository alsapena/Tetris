using System;
using System.Drawing;

namespace Tetris.Tools.Figures
{
    class Podium:Figure
    {
       
        public Podium(int x,int y,Color color)
        {
            Cells.Add(new Cell(x, y, 0, 1, color));
            Cells.Add(new Cell(x + 1, y, 0, 0, color));
            Cells.Add(new Cell(x + 1, y - 1, -1, 0, color));
            Cells.Add(new Cell(x + 1, y + 1, 1, 0, color));
        }
    }
}
