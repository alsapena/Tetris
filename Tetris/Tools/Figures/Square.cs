using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Tools.Figures
{
    class Square: Figure
    {
        
        public Square(int x,int y,Color color)
        {
            Cells.Add(new Cell(x, y, -1, 1, color));
            Cells.Add(new Cell(x, y + 1, 0, 1, color));
            Cells.Add(new Cell(x + 1, y, -1, 0, color));
            Cells.Add(new Cell(x + 1, y + 1, 0, 0, color));
        }

        public override void Rotate(Board b)
        {
            return;
        }
    }
}
