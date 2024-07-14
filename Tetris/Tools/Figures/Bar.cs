using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Tools.Figures
{
    public class Bar: Figure
    {
        public Bar(int x,int y,Color color)
        {
            Cells.Add(new Cell(x, y, 0, 1, color));
            Cells.Add(new Cell(x + 1, y, 0, 0, color));
            Cells.Add(new Cell(x + 2, y, 0, -1, color));
        }
    }
}
